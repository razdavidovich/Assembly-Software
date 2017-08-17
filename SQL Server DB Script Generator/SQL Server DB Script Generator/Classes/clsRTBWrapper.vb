'**********************************************************************************
'   Class: clsRTBWrapper.vb
' Purpose: Provide minipulation of RTF documents.
'          This is a stripped down class and only applys
'          the minimum information needed to create a working
'          RTF file.  The only attribute supported is foreground 
'          color and was written to provide context hilighting.
'
'  Author: Matthew Hazlett
'    Date: Jan, 30th, 2004
'
' Changes: Jan 31th 
'          Sucessfully transformed an entire document to color RTF.  
'          This turned out to be tremendiously slow in it's implementation
'          for editing for large documents.
'
'          Feb 1st
'          Changed code to provide on the fly streaming and modify
'          only a single line at a time.  Buggy Still !
'
'          Feb 2nd
'          Completly retooled the code to make it more efficent.  The class was 
'          getting to complex and needed a rewrite.
'
'          Why when I think I'm almost done do I find a pretty big snag.  
'          Everything's working great BUT the shifting headers on the RTF are
'          changing text on the other lines.  I guess I will have to make them
'          more static.  
'
'          GOT IT ! (Saved my dynamic headers !!!!)
'          Turns out after about 3 hours MS richedit was changing my RTF to their
'          prefered method.  Heh, well I ended up doing it the richedit way.  God
'          this control is tough.  So in conclusion this control is VERY PICKEY 
'          and if you change this code and screw it up don't come crying to me :-)
'
'          Feb 3nd
'          - Fixed Interface bugs where control were created in wrong sequence
'          - Fixed scroll bugs where text would scroll in viewport was full had had scrollbars
'          - Fixed mystery space bugs where on subsequent lines the second char could not be space
'          - Fixed } and { filtering bugs
'          (Maybe I should have been in pest control?)
'
'          Feb 4th
'          - Added support for mouse events
'          - Rewrote CurrentLine function to support wordwrap
'          - Fixed top line empty bugs
'          - Changed coloring scheme
'
'          Feb 5th
'          - Added better scroll handeling, LockWindow wasn't cutting 
'            the mustard by itself.
'          - 546 lines of code and more stuff to add!
'
'          Feb 6th
'          - Added RegEx matching (HTML, XML etc...) [ex. "<img.*>" = "<img src=regex.gif>"]
'          - Added caseInsensitive option
'          - Added Syntax Highlighter Form
'          - Added colorDocument method
'**********************************************************************************
Imports System.Text.RegularExpressions

Public Class clsRTBWrapper
    ' Scrollbar direction
    Const SBS_HORZ = 0
    Const SBS_VERT = 1

    ' Windows Messages
    Const WM_VSCROLL = &H115
    Const WM_HSCROLL = &H114
    Const SB_THUMBPOSITION = 4

    ' This is just a class structore that holds syntax options
    Public Class tDict
        Private _Pattern As String
        Private _isRegex As Boolean
        Private _ignoreCase As Boolean
        Private _color As Integer

        Public Sub New(ByVal thispattern As String, ByVal thisregex As Boolean, ByVal thisCase As Boolean, ByVal thisColor As Integer)
            _Pattern = thispattern
            _isRegex = thisregex
            _ignoreCase = thisCase
            _color = thisColor
        End Sub

        Public Property pattern() As String
            Get
                Return _Pattern
            End Get
            Set(ByVal Value As String)
                _Pattern = Value
            End Set
        End Property

        Public Property isRegex() As Boolean
            Get
                Return _isRegex
            End Get
            Set(ByVal Value As Boolean)
                _isRegex = Value
            End Set
        End Property

        Public Property ignoreCase() As Boolean
            Get
                Return _ignoreCase
            End Get
            Set(ByVal Value As Boolean)
                _ignoreCase = Value
            End Set
        End Property

        Public Property color() As Integer
            Get
                Return _color
            End Get
            Set(ByVal Value As Integer)
                _color = Value
            End Set
        End Property

    End Class

    ' This is just a dictionary class used to store your color info
    Public Class cDict
        Inherits CollectionBase

        Sub New()
        End Sub

        Sub add(ByVal Pattern As String, ByVal isRegex As Boolean, ByVal isCase As Boolean, ByVal value As Integer)
            If exists(Pattern) = -1 Then
                list.Add(New tDict(Pattern, isRegex, isCase, value))
            End If
        End Sub

        Public Property item(ByVal index As Integer) As Integer
            Get
                Return list(index)
            End Get
            Set(ByVal Value As Integer)
                list(index) = Value
            End Set
        End Property

        Function exists(ByVal lookup As String) As Integer
            Dim entry As tDict

            For Each entry In list
                If entry.pattern = lookup Then Return entry.color
            Next

            Return -1
        End Function

        Function index(ByVal lookup As String) As Integer
            Dim entry As tDict
            Dim thisIndex = 1

            For Each entry In list
                If entry.pattern = lookup Then Return thisIndex
                thisIndex += 1
            Next

            Return -1  ' Make it black
        End Function
    End Class

    ' This is just a list class used to store the headers color info
    Private Class cList
        Inherits CollectionBase

        Sub New()
        End Sub

        Sub add(ByVal item As Integer)
            If exists(item) = -1 Then
                list.Add(item)
                ' Console.WriteLine("New color: " & item)
            End If
        End Sub

        Public Property item(ByVal index As Integer) As Integer
            Get
                Return list(index)
            End Get
            Set(ByVal Value As Integer)
                list(index) = Value
                ' Console.WriteLine("Setting color")
            End Set
        End Property

        Function exists(ByVal lookup As Integer) As Integer
            Dim current As Integer

            If list.Count <> 0 Then
                For current = 0 To list.Count - 1
                    Dim compare As Color = Color.FromArgb(lookup)
                    Dim source As Color = Color.FromArgb(list(current))

                    ' This is very strange, the samme RGB color can have diffrent
                    ' ARGB values ???? Maybe its reporting 'A' diffrently, oh well
                    ' lets just work around that little feature

                    If compare.R = source.R And _
                       compare.G = source.G And _
                       compare.B = source.B Then
                        Return current
                    End If
                Next
            End If

            Return -1
        End Function
    End Class

    ' This is just a class used to store the position info
    Public Class cPosition
        Public Cursor As Integer
        Public CurrentLine As Integer
        Public LinePosition As Integer
        Public xScroll As Integer
        Public yScroll As Integer
    End Class

    ' Public events
    Public Event position(ByVal PositionInfo As cPosition)

    ' Vars
    Private WithEvents _bind As RichTextBox
    Public rtfSyntax As New cDict
    Private rtfColors As New cList
    Private rtfHeader As String
    Private rtfBody() As String
    Private txtBody() As String
    Private CursorPosition As cPosition
    Private RTFDebug As Boolean = True


    '--------------------------------------------------------------------------
    '     Sub: New
    ' Purpose: This was the most chalanging part of the entire project.
    '          How to write this, humm.  Maybe i'll save it till later.
    '          Ya, later!
    '
    Public Sub New()
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: Bind
    ' Purpose: Provide access to the object and its events
    '
    Public Sub bind(ByRef rtb As RichTextBox)
        _bind = rtb
        'AddHandler _bind.KeyUp, AddressOf update
        'AddHandler _bind.MouseUp, AddressOf update
        'AddHandler _bind.TextChanged, AddressOf update
    End Sub

    '--------------------------------------------------------------------------
    '     API: GetScrollPos
    ' Purpose: Returns an integer of the position of the scrollbar
    '
    Private Declare Function GetScrollPos Lib "user32.dll" ( _
        ByVal hWnd As IntPtr, _
        ByVal nBar As Integer) As Integer

    '--------------------------------------------------------------------------
    '     API: SetScrollPos
    ' Purpose: Sets the scrollbars to a certin value
    '
    Private Declare Function SetScrollPos Lib "user32.dll" ( _
        ByVal hWnd As IntPtr, ByVal nBar As Integer, _
        ByVal nPos As Integer, ByVal bRedraw As Boolean) As Integer

    '--------------------------------------------------------------------------
    '     API: PostMessageA
    ' Purpose: Sends a message to a control
    '
    Private Declare Function PostMessageA Lib "user32.dll" ( _
        ByVal hwnd As IntPtr, ByVal wMsg As Integer, _
        ByVal wParam As Integer, ByVal lParam As Integer) As Boolean

    '--------------------------------------------------------------------------
    '     API: LockWindowUpdate
    ' Purpose: Locks or Unlocks a window
    '
    Private Declare Function LockWindowUpdate Lib "user32.dll" (ByVal hwnd As Long) As Long

    '--------------------------------------------------------------------------
    '     Sub: Update
    ' Purpose: Reports the curssor position (Customized for word wrap support)
    '
    Private Overloads Sub update()
        CursorPosition = getCurrentPosition()
        RaiseEvent position(CursorPosition)
        debugprint(_bind.Rtf)
    End Sub
    Private Overloads Sub update(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        update()
    End Sub
    Private Overloads Sub update(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        update()
    End Sub
    Private Overloads Sub update(ByVal sender As Object, ByVal e As System.EventArgs)
        rtfColors.Clear()   ' Clear the colors
        readRTFColor()      ' Read and parse the colors in the current document
        readRTFBody()       ' Read and split the RTF into lines
        readTXTBody()       ' Read and split the text into lines
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: asciiprint
    ' Purpose: Help in debugging, converts line to ascii char numbers
    '
    Private Function asciiprint(ByVal str As String) As String
        Dim counter As Integer
        Dim retval As String = String.Empty

        For counter = 1 To str.Length
            retval &= "{" & Asc(Mid(str, counter, 1)) & "} "
        Next

        Return retval
    End Function

    '--------------------------------------------------------------------------
    '     Sub: debugprint
    ' Purpose: Prints out the current document substitutring non-printables
    '
    Private Sub debugprint(ByVal out As String)
        out = out.Replace(Chr(13) & Chr(10), Chr(182) & vbCrLf)
        out = out.Replace(Chr(32), Chr(183))
        Debug.WriteLine(out)
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: toggleDebug
    ' Purpose: Hide or show the debug window
    '
    Public Function toggleDebug() As Boolean
        RTFDebug = Not RTFDebug
        Return RTFDebug
    End Function

    '--------------------------------------------------------------------------
    '     Sub: getCurrentPosition
    ' Purpose: Determins relitive line position
    '
    Private Function getCurrentPosition() As cPosition
        Dim retval As New cPosition
        Dim counter As Integer

        retval.Cursor = _bind.SelectionStart

        If _bind.Text <> "" Then
            For counter = 0 To retval.Cursor - 1
                If _bind.Text.Substring(counter, 1) = Chr(10) Then
                    retval.CurrentLine += 1
                    retval.LinePosition = 0
                Else
                    retval.LinePosition += 1
                End If
            Next
        End If

        Return retval
    End Function

    '--------------------------------------------------------------------------
    '     Sub: saveScroll
    ' Purpose: saves the scroll info and locks the window
    '
    Private Sub saveScroll(ByVal hWnd As IntPtr)
        LockWindowUpdate(hWnd.ToInt32)

        CursorPosition.xScroll = GetScrollPos(_bind.Handle, SBS_HORZ)
        CursorPosition.yScroll = GetScrollPos(_bind.Handle, SBS_VERT)
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: restoreScroll
    ' Purpose: Resets the scroll info ans unlocks the window
    '
    Private Sub restoreScroll(ByVal hWnd As IntPtr)
        SetScrollPos(_bind.Handle, SBS_HORZ, CursorPosition.xScroll, True)
        PostMessageA(_bind.Handle, WM_HSCROLL, SB_THUMBPOSITION + &H10000 * CursorPosition.xScroll, Nothing)
        SetScrollPos(_bind.Handle, SBS_VERT, CursorPosition.yScroll, True)
        PostMessageA(_bind.Handle, WM_VSCROLL, SB_THUMBPOSITION + &H10000 * CursorPosition.yScroll, Nothing)

        LockWindowUpdate(0&)
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: _bind_TextChanged
    ' Purpose: Do the highlighting
    '
    Private Sub _bind_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _bind.KeyUp
        If e.KeyData = Keys.Space Then
            update()                     ' Update the cursor position
            saveScroll(_bind.Handle)     ' Freeze the windows and get the scroll nfo

            applyColor(CursorPosition.CurrentLine)        ' Do any coloring
            _bind.Rtf = Render()                          ' Update the RTF
            _bind.SelectionStart = CursorPosition.Cursor  ' Reset the cursor
            debugprint(_bind.Rtf)                         ' Update the debug window

            restoreScroll(_bind.Handle) ' Unfreeze the windows and Restore the scroll
        End If
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: readRTFColor()
    ' Purpose: parse the color information in the header of the document
    '
    Private Function readRTFColor() As Boolean
        Dim strHeader As String = ""

        ' Get Header string
        ' I hate RegEx :-)
        '
        Dim colHeader As MatchCollection = Regex.Matches(_bind.Rtf, "{\\colortbl\s?;(.*);}")

        If RTFDebug Then Console.WriteLine("Colors found: " & colHeader.Count)

        If colHeader.Count = 1 Then
            strHeader = colHeader.Item(0).Groups(1).Value
            If RTFDebug Then Console.WriteLine(colHeader.Item(0).Groups(1).Value)
        Else
            If RTFDebug Then Console.WriteLine("No color info in header")
            Return False
        End If

        ' Translate the string to ARGB color values
        ' I hate RegEx :-)
        '
        Dim colColors As MatchCollection = Regex.Matches(strHeader, "(\d+)")

        If Not colColors Is Nothing Then
            Dim colorCounter As Integer

            For colorCounter = 0 To colColors.Count - 1 Step 3
                Dim newColor As Color = Color.FromArgb(0, _
                                        colColors.Item(colorCounter).Value, _
                                        colColors.Item(colorCounter + 1).Value, _
                                        colColors.Item(colorCounter + 2).Value)

                rtfColors.add(newColor.ToArgb)
            Next
        End If
    End Function

    '--------------------------------------------------------------------------
    '     Sub: readRTFBody()
    ' Purpose: Read the RTF and strip off the header info, and split it into limes.
    '          RegEx avoided here !
    '
    Private Function readRTFBody() As String
        Dim tmp As String = _bind.Rtf
        Dim bodyStart As Integer

        Dim position As Integer = InStr(tmp, "\viewkind4")
        If InStr(position, tmp, " ") < 0 Then
            bodyStart = InStr(position, tmp, "\par")
        Else
            bodyStart = InStr(position, tmp, " ")
        End If

        Dim tmpRtfBody As String = tmp.Substring(bodyStart)
        rtfBody = Split(tmpRtfBody, "\par")
        Return String.Empty

    End Function

    '--------------------------------------------------------------------------
    '     Sub: readTXTBody()
    ' Purpose: Split the text portion into lines
    '          RegEx avoided here !
    '
    Private Function readTXTBody() As String
        Dim tmpText As String
        Dim counter As Integer

        tmpText = _bind.Text
        txtBody = Split(tmpText, Chr(10))

        For counter = 0 To UBound(txtBody)
            If txtBody(counter) Is Nothing Then
                txtBody(counter) = ""
            End If
        Next

        If RTFDebug Then Console.WriteLine("")
        If RTFDebug Then Console.WriteLine("Text lines read: " & UBound(txtBody))
        Return String.Empty
    End Function

    '--------------------------------------------------------------------------
    '     Sub: Render()
    ' Purpose: Put the moded RTF back together
    '
    Private Function Render() As String
        Dim tmp As String = reBuildBody()
        Return reBuildHeader() & "\viewkind4 " & reBuildBody()
    End Function

    '--------------------------------------------------------------------------
    '     Sub: reBuildHeader()
    ' Purpose: Using the colortable supplied by readRTFColor() rebuilds the 
    '          headers after all you might have added a color!
    '
    Private Function reBuildHeader() As String
        Dim thisColor As Integer
        Dim DocHead As String

        DocHead = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033"
        DocHead &= "{\colortbl ;"

        For Each thisColor In rtfColors
            Dim setColor As Color = Color.FromArgb(thisColor)
            DocHead &= "\red" & setColor.R
            DocHead &= "\green" & setColor.G
            DocHead &= "\blue" & setColor.B & ";"
            If RTFDebug Then Console.WriteLine("Adding Header Color")
        Next

        DocHead &= "}"
        Return DocHead
    End Function

    '--------------------------------------------------------------------------
    '     Sub: reBuildBody()
    ' Purpose: Build the moded RTF Body
    '
    Private Function reBuildBody() As String
        Dim DocBody As String = ""
        Dim rtfLine As String = ""
        Dim counter As Integer

        For counter = 0 To UBound(rtfBody)
            Dim tmp As String = rtfBody(counter)
            If tmp = "" Then tmp = " "
            DocBody &= tmp & "\par" & vbCrLf
        Next

        If RTFDebug Then Console.WriteLine("RTF body lines rendered: " & UBound(rtfBody))
        Return DocBody
    End Function

    '--------------------------------------------------------------------------
    '     Sub: ChangeColor
    ' Purpose: Change the color of an element document wide.  Basicly this changes
    '          the info in the color table used to build the headers.  
    '    Note: This changes a color to a color
    '
    Private Sub changeColor(ByVal srcColor As Color, ByVal toColor As Color)
        Dim index = rtfColors.exists(srcColor.ToArgb)

        If index <> -1 Then
            rtfColors.item(index) = toColor.ToArgb
        End If
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: ChangeColor
    ' Purpose: Change the color of an element document wide.  Basicly this changes
    '          the info in the color table used to build the headers.  
    '    Note: This changes a index value of a color to a color
    '
    Public Sub changeColor(ByVal index As Integer, ByVal toColor As Color)
        rtfColors.item(index) = toColor.ToArgb
    End Sub

    '--------------------------------------------------------------------------
    '     Sub: applyColor
    ' Purpose: Apply a new color format to a line
    '
    Private Sub applyColor(ByVal line As Integer)
        Dim thisMatch As Match
        Dim Style As tDict
        Dim rxOptions As New RegexOptions
        Dim colorindex As Integer

        rtfBody(line) = txtBody(line)

        For Each Style In rtfSyntax
            If Style.ignoreCase Then rxOptions = RegexOptions.IgnoreCase Else rxOptions = RegexOptions.None

            rtfColors.add(Style.color)
            colorindex = rtfColors.exists(Style.color)

            If Style.isRegex Then
                Dim Matches As MatchCollection = Regex.Matches(rtfBody(line), Style.pattern, rxOptions)
                Dim count As Integer = 0

                For Each thisMatch In Matches
                    Dim oldWord = rtfBody(line).Substring(thisMatch.Index + count, thisMatch.Length)
                    Dim newString = "\cf" & colorindex + 1 & oldWord & "\cf0 "

                    rtfBody(line) = rtfBody(line).Remove(thisMatch.Index + count, thisMatch.Length)
                    rtfBody(line) = rtfBody(line).Insert(thisMatch.Index + count, newString)
                    If RTFDebug Then Console.WriteLine("Regex pattern match: " & Style.pattern)
                    count += 9
                Next
            Else
                Dim Matches As MatchCollection = Regex.Matches(rtfBody(line), "\b" & Style.pattern & "\b", rxOptions)
                Dim count As Integer = 0

                For Each thisMatch In Matches
                    Dim oldWord = rtfBody(line).Substring(thisMatch.Index + count, thisMatch.Length)
                    Dim newString = "\cf" & colorindex + 1 & oldWord & "\cf0 "

                    rtfBody(line) = rtfBody(line).Remove(thisMatch.Index + count, thisMatch.Length)
                    rtfBody(line) = rtfBody(line).Insert(thisMatch.Index + count, newString)
                    count += 9
                    If RTFDebug Then Console.WriteLine("Pattern match: " & Style.pattern)
                Next
            End If
        Next

    End Sub

    Public Sub colorDocument()
        Dim counter As Integer
        update(Me, New System.EventArgs)

        For counter = 0 To UBound(txtBody)
            applyColor(counter)
        Next

        _bind.Rtf = Render()
    End Sub
End Class
