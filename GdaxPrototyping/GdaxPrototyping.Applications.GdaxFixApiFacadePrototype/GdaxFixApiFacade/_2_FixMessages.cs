// All messages.
//    Fields to populate:
//       {SenderCompID}.
//          This equals the key that you need to generate via their user interface.
//          todo Cross-reference with Comment201802141. Maybe move it here.

// {Logon}.
//    Fields to populate:
//       {RawData}.
//          This is a signature that needs to be be calculated.
//       {Password}.
//          This equals the passphrase that you need to generate via their user interface.
//       // {CancelOrdersOnDisconnect}.

// // yg? {Reject}.

// {NewOrderSingle}.
//    Fields to populate:
// todo ???      {SendingTime}.
//          May be second resolution.
//          May not be in a distant future.
//       {ClOrdID}.
//          todo UUID?
// todo ???      // {HandlInst}.
//       //    Values:
//       //       '1' = {AutomatedExecutionNoIntervention}.
//       {Symbol}.
//       {Side}.
//          Values:
//             '1' = {Buy}.
//             '2' = {Sell}.
//       {OrderQty}.
//          todo I received an error: Order size is too small. Minimum size is 0.01
//       {CashOrderQty}.
//          todo Either {OrderQty} or {CashOrderQty} need to be given, not both, right? Cross-ref.
//       {OrdType}.
//          Values:
//             '1' = {Market}.
//             '2' = {Limit}.
//             '3' = {StopMarket}.
//       {Price}.
//          Conditional.
//       {StopPx}.
//          Conditional.
//       {TimeInForce}.
//          Conditional.
//          todo 58=TimeInForce is not allowed for market orders
//          Values:
//             '1' = {GoodTillCancel}.
//             '3' = {ImmediateOrCancel}.
//             '4' = {FillOrKill}.
//             'P' = {PostOnly}.
//       // yg? {SelfTradePrevention}.

// {ExecutionReport}.
//    Fields to read:
// todo OrderQty as accepted (may be less than requested upon self-trade prevention)
// todo ???      {OrigClOrdID}.
// todo ???         Optional.
//       {ClOrdID}.
//          todo phrase better: Only present on order acknowledgements, ExecType=New (150=0)
//       {OrderID}.
//       {OrdStatus}.
//          Values:
//             todo Values are not documented. So expect all completion values. Maybe except {Expired}.
//             '2' = {Filled}.
//             '4' = {Canceled}.
//             '8' = {Rejected}.
//             // yg? 'C' = {Expired}.
// todo?//       {CumQty}.
// todo?//       {AvgPx}.
// todo?//       {Text}.
// todo?//          Optional.

// {OrderCancelRequest}.
//    Fields to populate:
//       {OrigClOrdID}.
//          todo UUID?
// todo Also {OrderID}?
//       {ClOrdID}.
//          todo UUID?
// todo Also {Symbol}?

// // {OrderCancelReject}.

// {OrderStatusRequest}.
//    Fields to populate:
//       {OrderID}.
//          todo phrase better: Can be equal to * (wildcard) to send back all pending orders
//          todo phrase better and cross-ref: If the user has no open orders, a single ExecutionReport is sent back with OrderID=0.
