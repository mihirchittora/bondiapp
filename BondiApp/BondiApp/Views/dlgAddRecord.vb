' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On


Friend Class dlgAddRecord
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblSymbol As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblLimitPrice As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblQty As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblAction As Label
    Public WithEvents cmdOk As Button
    Friend WithEvents Label4 As Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLimitPrice = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAction = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSymbol = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lblStatus)
        Me.Frame1.Controls.Add(Me.Label10)
        Me.Frame1.Controls.Add(Me.lblLimitPrice)
        Me.Frame1.Controls.Add(Me.Label8)
        Me.Frame1.Controls.Add(Me.lblQty)
        Me.Frame1.Controls.Add(Me.Label6)
        Me.Frame1.Controls.Add(Me.lblAction)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.lblSymbol)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(665, 62)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Record to be added Perm ID: "
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(494, 28)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(51, 16)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Label2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(442, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Status:"
        '
        'lblLimitPrice
        '
        Me.lblLimitPrice.AutoSize = True
        Me.lblLimitPrice.Location = New System.Drawing.Point(372, 28)
        Me.lblLimitPrice.Name = "lblLimitPrice"
        Me.lblLimitPrice.Size = New System.Drawing.Size(51, 16)
        Me.lblLimitPrice.TabIndex = 9
        Me.lblLimitPrice.Text = "Label2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(332, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Price:"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(275, 28)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(51, 16)
        Me.lblQty.TabIndex = 7
        Me.lblQty.Text = "Label2"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(242, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Qty:"
        '
        'lblAction
        '
        Me.lblAction.AutoSize = True
        Me.lblAction.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblAction.Location = New System.Drawing.Point(185, 28)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.Size = New System.Drawing.Size(51, 16)
        Me.lblAction.TabIndex = 5
        Me.lblAction.Text = "Label2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(136, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Action:"
        '
        'lblSymbol
        '
        Me.lblSymbol.AutoSize = True
        Me.lblSymbol.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblSymbol.Location = New System.Drawing.Point(62, 28)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.Size = New System.Drawing.Size(51, 16)
        Me.lblSymbol.TabIndex = 3
        Me.lblSymbol.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Symbol:"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(531, 84)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(81, 25)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(452, 83)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'dlgAddRecord
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(680, 120)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdClose)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(315, 341)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAddRecord"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Record Confirmation"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgAddRecord
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgAddRecord
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgAddRecord()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Private m_utils As Utils
    Private m_ok As Boolean = False
    Private m_accountName As String
    Private m_complete As Boolean

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================

    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        ' clear any existing list details
        'lstKeyValueData.Items.Clear()
        'lstPortfolioData.Items.Clear()
        'txtLastUpdateTime.Text = "00:00"

        Hide()
    End Sub

    ' ========================================================
    ' Public methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Class initializer. Make utilites available to this class
    '--------------------------------------------------------------------------------
    Public Sub init(ByVal utilities As Utils)
        m_utils = utilities
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates a user account property
    '--------------------------------------------------------------------------------
    Public Sub updateAccountValue(ByRef key As String, ByRef val_Renamed As String, ByRef curency As String, ByRef accountName As String)
        Dim msg As String

        msg = "key=" & key & " value=" & val_Renamed & " currency=" & curency & " account=" & accountName
        Call m_utils.addListItem(Utils.List_Types.ACCOUNT_DATA, msg)
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates a portfolio position details
    '--------------------------------------------------------------------------------
    Public Sub updatePortfolio(ByVal contract As IBApi.Contract, ByRef position As Integer, ByRef marketPrice As Double, ByRef marketValue As Double, ByRef averageCost As Double, ByRef unrealizedPNL As Double, ByRef realizedPNL As Double, ByRef accountName As String)
        Dim msg As String

        With contract
            msg = "conId=" & .ConId & " symbol=" & .Symbol & " secType=" & .SecType & " lastTradeDate=" & .LastTradeDateOrContractMonth & " strike=" & .Strike _
            & " right=" & .Right & " multiplier=" & .Multiplier & " primaryExch=" & .PrimaryExch & " currency=" & .Currency _
            & " localSymbol=" & .LocalSymbol & " tradingClass=" & .TradingClass & " position=" & position & " mktPrice=" & marketPrice & " mktValue=" & marketValue _
            & " avgCost=" & averageCost & " unrealizedPNL=" & unrealizedPNL & " realizedPNL=" & realizedPNL & " account=" & accountName
        End With
        Call m_utils.addListItem(Utils.List_Types.PORTFOLIO_DATA, msg)
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates the server clock time
    '--------------------------------------------------------------------------------
    Public Sub updateAccountTime(ByRef timeStamp As String)
        'txtLastUpdateTime.Text = timeStamp
    End Sub

    Public Sub accountDownloadBegin(ByVal accountName As String)
        m_accountName = accountName
        m_complete = False
        Call updateTitle()
    End Sub

    Public Sub accountDownloadEnd(ByVal accountName As String)
        If Len(m_accountName) <> 0 And m_accountName <> accountName Then
            Return
        End If

        m_complete = True
        Call updateTitle()
    End Sub

    Private Sub updateTitle()

        Dim title As String
        title = ""

        If Len(m_accountName) <> 0 Then
            title = m_accountName
        End If
        If m_complete Then
            If Len(title) <> 0 Then
                title = title & " "
            End If
            title = title & "[complete]"
        End If

        Me.Text = title

    End Sub

    Private Sub Frame2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs)
        m_ok = True

        Close()
    End Sub

    Private Sub cmdOk_Click_1(sender As Object, e As EventArgs) Handles cmdOk.Click
        m_ok = True

        Close()
    End Sub
End Class
