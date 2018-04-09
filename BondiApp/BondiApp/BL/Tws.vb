Imports System.Linq
Imports System.Collections.Generic
Imports IBApi





Friend Class Tws
    Implements IBApi.EWrapper

    Dim eReaderSignal As EReaderSignal = New EReaderMonitorSignal
    Dim socket As IBApi.EClientSocket = New IBApi.EClientSocket(Me, eReaderSignal)

    Dim form As Form
    Public Property StockTickPrice As Double

    Sub New(form As Form)
        Me.form = form
    End Sub

    Sub InvokeIfRequired(del As [Delegate])
        If form.InvokeRequired Then
            form.Invoke(del)
        Else
            del.DynamicInvoke()
        End If
    End Sub

    ' CUSTOM CODE ADDED 

    Function serverVersion() As Integer                                                                                                     ' USED TO DETERMINE WHETHER THE APP IS CONNECTED TO TWS
        serverVersion = socket.ServerVersion
    End Function

    Function TwsConnectionTime() As String                                                                                                  ' RETURNS THE SERVERTIME FROM TWS
        TwsConnectionTime = socket.ServerTime
    End Function

    Sub reqIds(p1 As Integer)
        socket.reqIds(p1)
    End Sub

    Sub reqMarketDataType(p1 As Integer)
        socket.reqMarketDataType(p1)
    End Sub

    Sub reqMktDataEx(tickerId As Integer, m_contractInfo As IBApi.Contract, genericTicks As String, snapshot As Boolean, m_mktDataOptions As Generic.List(Of IBApi.TagValue))
        socket.reqMktData(tickerId, m_contractInfo, genericTicks, snapshot, m_mktDataOptions)
    End Sub

    Sub placeOrderEx(p1 As Integer, m_contractInfo As IBApi.Contract, m_orderInfo As IBApi.Order)
        socket.placeOrder(p1, m_contractInfo, m_orderInfo)
        nextValidId(m_orderInfo.OrderId + 1)
    End Sub

    Sub cancelOrder(p1 As Integer)
        socket.cancelOrder(p1)
    End Sub

    Private Sub msgProcessing()
        Dim reader As EReader = New EReader(socket, eReaderSignal)

        reader.Start()

        While socket.IsConnected
            eReaderSignal.waitForSignal()
            InvokeIfRequired(Sub() reader.processMsgs())
        End While
    End Sub

    ' SHIPPED CODE WITH TWS API
    Public Sub connectAck() Implements EWrapper.connectAck
        If socket.AsyncEConnect Then
            socket.startApi()
        End If
    End Sub

    Sub connect(p1 As String, p2 As Integer, p3 As Integer, p4 As Boolean, optcapts As String)                                              ' CONNECTION STRING & FUNCTION USED TO CONNECT THE APP TO TWS
        socket.optionalCapabilities = optcapts

        socket.eConnect(p1, p2, p3, p4)

        Dim msgThread As Threading.Thread = New Threading.Thread(AddressOf msgProcessing)

        msgThread.IsBackground = True

        If serverVersion() > 0 Then Call msgThread.Start()
    End Sub

    Sub disconnect()
        socket.eDisconnect()
    End Sub

    Public Sub [error](e As Exception) Implements EWrapper.error
        Throw New NotImplementedException()
    End Sub

    Public Sub [error](str As String) Implements EWrapper.error
        Throw New NotImplementedException()
    End Sub





    ' USE THIS TO LOG ERRORS OR DISPLAY ERRORS TO THE USER
    Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements EWrapper.error
        'Throw New NotImplementedException()
    End Sub









    Public Sub currentTime(time As Long) Implements EWrapper.currentTime
        Throw New NotImplementedException()
    End Sub
    Public tickCount As Integer = 0

    Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, canAutoExecute As Integer) Implements EWrapper.tickPrice
        'Throw New NotImplementedException()
        socket.cancelMktData(tickerId)
        tickCount = tickCount + 1
        InvokeIfRequired(Sub()
                             RaiseEvent OnTickPrice(Me, New AxTWSLib._DTwsEvents_tickPriceEvent With {.id = tickerId, .price = price, .tickType = field, .canAutoExecute = canAutoExecute, .tickCount = tickCount})
                         End Sub)
    End Sub
    Public Sub cancelMarketData(tickerId As Integer)
        socket.cancelMktData(tickerId)
    End Sub

    Public Sub tickSize(tickerId As Integer, field As Integer, size As Integer) Implements EWrapper.tickSize
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnTickSize(Me, New AxTWSLib._DTwsEvents_tickSizeEvent With {.id = tickerId, .size = size, .TickType = field})
                         End Sub)

    End Sub

    Public Sub tickString(tickerId As Integer, field As Integer, value As String) Implements EWrapper.tickString
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnTickString(Me, New AxTWSLib._DTwsEvents_tickStringEvent With {.id = tickerId, .TickType = field, .value = value})
                         End Sub)

    End Sub

    Public Sub tickGeneric(tickerId As Integer, field As Integer, value As Double) Implements EWrapper.tickGeneric
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnTickGeneric(Me, New AxTWSLib._DTwsEvents_tickGenericEvent With {.id = tickerId, .tickType = field, .value = value})
                         End Sub)

    End Sub

    Public Sub tickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double) Implements EWrapper.tickEFP
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnTickEFP(Me, New AxTWSLib._DTwsEvents_tickEFPEvent With {
                                                                                      .tickerId = tickerId,
                                                                                      .field = tickType,
                                                                                      .basisPoints = basisPoints,
                                                                                      .formattedBasisPoints = formattedBasisPoints,
                                                                                      .impliedFuture = impliedFuture,
                                                                                      .holdDays = holdDays,
                                                                                      .futureLastTradeDate = futureLastTradeDate,
                                                                                      .dividendImpact = dividendImpact,
                                                                                      .dividendsToLastTradeDate = dividendsToLastTradeDate
                                                                                  })
                         End Sub)

    End Sub

    Public Sub deltaNeutralValidation(reqId As Integer, underComp As UnderComp) Implements EWrapper.deltaNeutralValidation
        Throw New NotImplementedException()
    End Sub

    Public Sub tickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements EWrapper.tickOptionComputation
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnTickOptionComputation(Me, New AxTWSLib._DTwsEvents_tickOptionComputationEvent With {
                                                                                                    .tickerId = tickerId,
                                                                                                    .tickType = field,
                                                                                                    .impliedVolatility = impliedVolatility,
                                                                                                    .delta = delta,
                                                                                                    .optPrice = optPrice,
                                                                                                    .pvDividend = pvDividend,
                                                                                                    .gamma = gamma,
                                                                                                    .vega = vega,
                                                                                                    .theta = theta,
                                                                                                    .undPrice = undPrice
                                                                 })
                         End Sub)

    End Sub

    Public Sub tickSnapshotEnd(tickerId As Integer) Implements EWrapper.tickSnapshotEnd
        Throw New NotImplementedException()
    End Sub


    Public Sub nextValidId(orderId As Integer) Implements EWrapper.nextValidId
        InvokeIfRequired(Sub()
                             RaiseEvent OnNextValidId(Me, New _DTwsEvents_nextValidIdEvent With {.Id = orderId})
                         End Sub)
    End Sub




    Public Sub managedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts
        InvokeIfRequired(Sub()
                             RaiseEvent OnmanagedAccounts(Me, New _DTwsEvents_managedAccountsEvent With {
                                                                 .accountsList = accountsList
                                                                 })
                         End Sub)
    End Sub

    Public Sub connectionClosed() Implements EWrapper.connectionClosed
        'Throw New NotImplementedException()
    End Sub

    Public Sub accountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements EWrapper.accountSummary
        Throw New NotImplementedException()
    End Sub

    Public Sub accountSummaryEnd(reqId As Integer) Implements EWrapper.accountSummaryEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub bondContractDetails(reqId As Integer, contract As ContractDetails) Implements EWrapper.bondContractDetails
        Throw New NotImplementedException()
    End Sub

    Public Sub updateAccountValue(key As String, value As String, currency As String, accountName As String) Implements EWrapper.updateAccountValue
        Throw New NotImplementedException()
    End Sub

    Public Sub updatePortfolio(contract As Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements EWrapper.updatePortfolio
        Throw New NotImplementedException()
    End Sub

    Public Sub updateAccountTime(timestamp As String) Implements EWrapper.updateAccountTime
        Throw New NotImplementedException()
    End Sub

    Public Sub accountDownloadEnd(account As String) Implements EWrapper.accountDownloadEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus
        InvokeIfRequired(Sub()
                             RaiseEvent OnorderStatus(Me, New _DTwsEvents_orderStatusEvent With {
                                                                 .orderId = orderId,
                                                                  .status = status,
                                                                  .filled = filled,
                                                                  .remaining = remaining,
                                                                  .avgFillPrice = avgFillPrice,
                                                                  .permId = permId,
                                                                  .parentId = parentId,
                                                                  .lastFillPrice = lastFillPrice,
                                                                  .clientId = clientId,
                                                                  .whyHeld = whyHeld
                                                                 })
                         End Sub)
    End Sub


    Public Sub openOrder(orderId As Integer, contract As Contract, order As Order, orderState As OrderState) Implements EWrapper.openOrder
        InvokeIfRequired(Sub()
                             RaiseEvent OnopenOrderEx(Me, New _DTwsEvents_openOrderExEvent With {
                                                                 .orderId = orderId,
                                                                  .contract = contract,
                                                                  .order = order,
                                                                  .orderState = orderState
                                                                 })
                         End Sub)
    End Sub

    Public Sub openOrderEnd() Implements IBApi.EWrapper.openOrderEnd
        InvokeIfRequired(Sub()
                             RaiseEvent OnopenOrderEnd(Me, EventArgs.Empty)
                         End Sub)
    End Sub

    Public Sub contractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails
        InvokeIfRequired(Sub()
                             RaiseEvent OncontractDetailsEx(Me, New _DTwsEvents_contractDetailsExEvent With {
                                                                 .reqId = reqId,
                                                                  .contractDetails = contractDetails
                                                                 })
                         End Sub)
    End Sub

    Public Sub contractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd
        InvokeIfRequired(Sub()
                             RaiseEvent OncontractDetailsEnd(Me, New _DTwsEvents_contractDetailsEndEvent With {
                                                                 .reqId = reqId
                                                                 })
                         End Sub)
    End Sub

    Public Sub execDetails(reqId As Integer, contract As Contract, execution As Execution) Implements EWrapper.execDetails
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnexecDetailsEx(Me, New AxTWSLib._DTwsEvents_execDetailsExEvent With {
                                                                 .reqId = reqId,
                                                                  .contract = contract,
                                                                  .execution = execution
                                                                 })
                         End Sub)

    End Sub

    Public Sub execDetailsEnd(reqId As Integer) Implements EWrapper.execDetailsEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub commissionReport(commissionReport As CommissionReport) Implements EWrapper.commissionReport
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OncommissionReport(Me, New AxTWSLib._DTwsEvents_commissionReportEvent With {
                                                                 .commissionReport = commissionReport
                                                                 })
                         End Sub)


    End Sub

    Public Sub fundamentalData(reqId As Integer, data As String) Implements EWrapper.fundamentalData
        Throw New NotImplementedException()
    End Sub

    Public Sub historicalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements EWrapper.historicalData
        Throw New NotImplementedException()
    End Sub

    Public Sub historicalDataEnd(reqId As Integer, start As String, [end] As String) Implements EWrapper.historicalDataEnd
        Throw New NotImplementedException()
    End Sub




    Public Sub marketDataType(reqId As Integer, marketDataType As Integer) Implements EWrapper.marketDataType
        'Throw New NotImplementedException()

        InvokeIfRequired(Sub()
                             RaiseEvent OnmarketDataType(Me, New AxTWSLib._DTwsEvents_marketDataTypeEvent With {
                                                                 .reqId = reqId,
                                                                  .marketDataType = marketDataType
                                                                 })
                         End Sub)

    End Sub








    Public Sub updateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements EWrapper.updateMktDepth
        Throw New NotImplementedException()
    End Sub

    Public Sub updateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements EWrapper.updateMktDepthL2
        Throw New NotImplementedException()
    End Sub

    Public Sub updateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements EWrapper.updateNewsBulletin
        Throw New NotImplementedException()
    End Sub

    Public Sub position(account As String, contract As Contract, pos As Double, avgCost As Double) Implements EWrapper.position
        Throw New NotImplementedException()
    End Sub

    Public Sub positionEnd() Implements EWrapper.positionEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub realtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements EWrapper.realtimeBar
        Throw New NotImplementedException()
    End Sub

    Public Sub scannerParameters(xml As String) Implements EWrapper.scannerParameters
        Throw New NotImplementedException()
    End Sub

    Public Sub scannerData(reqId As Integer, rank As Integer, contractDetails As ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements EWrapper.scannerData
        Throw New NotImplementedException()
    End Sub

    Public Sub scannerDataEnd(reqId As Integer) Implements EWrapper.scannerDataEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub receiveFA(faDataType As Integer, faXmlData As String) Implements EWrapper.receiveFA
        Throw New NotImplementedException()
    End Sub

    Public Sub verifyMessageAPI(apiData As String) Implements EWrapper.verifyMessageAPI
        Throw New NotImplementedException()
    End Sub

    Public Sub verifyCompleted(isSuccessful As Boolean, errorText As String) Implements EWrapper.verifyCompleted
        Throw New NotImplementedException()
    End Sub

    Public Sub verifyAndAuthMessageAPI(apiData As String, xyzChallenge As String) Implements EWrapper.verifyAndAuthMessageAPI
        Throw New NotImplementedException()
    End Sub

    Public Sub verifyAndAuthCompleted(isSuccessful As Boolean, errorText As String) Implements EWrapper.verifyAndAuthCompleted
        Throw New NotImplementedException()
    End Sub

    Public Sub displayGroupList(reqId As Integer, groups As String) Implements EWrapper.displayGroupList
        Throw New NotImplementedException()
    End Sub

    Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String) Implements EWrapper.displayGroupUpdated
        Throw New NotImplementedException()
    End Sub

    Public Sub positionMulti(requestId As Integer, account As String, modelCode As String, contract As Contract, pos As Double, avgCost As Double) Implements EWrapper.positionMulti
        Throw New NotImplementedException()
    End Sub

    Public Sub positionMultiEnd(requestId As Integer) Implements EWrapper.positionMultiEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub accountUpdateMulti(requestId As Integer, account As String, modelCode As String, key As String, value As String, currency As String) Implements EWrapper.accountUpdateMulti
        Throw New NotImplementedException()
    End Sub

    Public Sub accountUpdateMultiEnd(requestId As Integer) Implements EWrapper.accountUpdateMultiEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub securityDefinitionOptionParameter(reqId As Integer, exchange As String, underlyingConId As Integer, tradingClass As String, multiplier As String, expirations As HashSet(Of String), strikes As HashSet(Of Double)) Implements EWrapper.securityDefinitionOptionParameter
        Throw New NotImplementedException()
    End Sub

    Public Sub securityDefinitionOptionParameterEnd(reqId As Integer) Implements EWrapper.securityDefinitionOptionParameterEnd
        Throw New NotImplementedException()
    End Sub

    Public Sub softDollarTiers(reqId As Integer, tiers() As SoftDollarTier) Implements EWrapper.softDollarTiers
        Throw New NotImplementedException()
    End Sub

    ' EVENTS USED IN THE INTERACTION BETWEEN THE APP AND THE API

    Event OnNextValidId(ByVal sender As Object, ByVal eventArgs As _DTwsEvents_nextValidIdEvent)
    Event OnmanagedAccounts(tws As Tws, DTwsEvents_managedAccountsEvent As _DTwsEvents_managedAccountsEvent)
    Event OnorderStatus(tws As Tws, DTwsEvents_orderStatusEvent As _DTwsEvents_orderStatusEvent)
    Event OnopenOrderEnd(tws As Tws, Empty As EventArgs)
    Event OnopenOrderEx(tws As Tws, DTwsEvents_openOrderExEvent As _DTwsEvents_openOrderExEvent)
    Event OncontractDetailsEx(tws As Tws, DTwsEvents_contractDetailsExEvent As _DTwsEvents_contractDetailsExEvent)
    Event OncontractDetailsEnd(tws As Tws, DTwsEvents_contractDetailsEndEvent As _DTwsEvents_contractDetailsEndEvent)
    Event OnexecDetailsEx(tws As Tws, DTwsEvents_execDetailsExEvent As AxTWSLib._DTwsEvents_execDetailsExEvent)
    Event OncommissionReport(tws As Tws, DTwsEvents_commissionReportEvent As AxTWSLib._DTwsEvents_commissionReportEvent)

    Event OnmarketDataType(tws As Tws, DTwsEvents_marketDataTypeEvent As AxTWSLib._DTwsEvents_marketDataTypeEvent)

    Event OnTickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent)
    Event OnTickSize(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickSizeEvent)
    Event OnTickGeneric(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickGenericEvent)
    Event OnTickString(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickStringEvent)
    Event OnTickEFP(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickEFPEvent)
    Event OnTickOptionComputation(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickOptionComputationEvent)

End Class
