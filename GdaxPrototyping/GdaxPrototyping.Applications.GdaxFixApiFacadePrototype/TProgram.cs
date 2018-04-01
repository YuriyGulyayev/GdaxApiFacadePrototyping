namespace GdaxPrototyping.Applications.GdaxFixApiFacadePrototype
{
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   internal static class TProgram
   {
      #region // Data.

      //private static double BestBidPrice_;
      //private static double BestAskPrice_;
      //private static string OrderBrokerageAssignedGuidAsString_;

      #endregion

      #region {private Main}.

      private static void Main
         ( //string[] args
         )
      {
         {
            var LoggingHelpersConfiguration =
               new Common.Core.Diagnostics.TLoggingHelpersConfiguration()
               {
                  MainLogFilePathName = @"Data/Log_<DateTimeStamp>.txt"
               };
            LoggingHelpersConfiguration.Prepare(@".");
            Common.Core.Diagnostics.TLoggingHelpers.Prepare(LoggingHelpersConfiguration);
         }

         //System.Threading.Monitor.Enter(Common.Core.Threading.TThreadingHelpers.MainLockable);
         Common.Core.Diagnostics.TLoggingHelpers.LogLogRecord(@"Info; starting; if we crash examine the operating system event log");
         //System.Threading.Monitor.Exit(Common.Core.Threading.TThreadingHelpers.MainLockable);
         ThreadSafeRun();
         System.Media.SystemSounds.Beep.Play();
         System.Threading.Thread.Sleep(3500);
         System.Threading.Monitor.Enter(Common.Core.Threading.TThreadingHelpers.MainLockable);
         Common.Core.Diagnostics.TLoggingHelpers.LogLogRecord(@"Info; terminating; we didn't crash so far");

         // Comment201704221 relates and/or applies.
         Common.Core.Diagnostics.TLoggingHelpers.MainLogStreamWriter.Flush();

         System.Threading.Monitor.Exit(Common.Core.Threading.TThreadingHelpers.MainLockable);
         System.Media.SystemSounds.Beep.Play();
      }

      #endregion

      #region {private ThreadSafeRun}.

      private static void ThreadSafeRun()
      {
         #region

         System.Threading.Monitor.Enter(Common.Core.Threading.TThreadingHelpers.MainLockable);
         var fixSessionSettings = new QuickFix.SessionSettings(@".\Data\FixSessionConfiguration.ini");
         var fixInitiatorApplication = new GdaxFixApiFacade.TFixInitiatorApplication(@"Test", fixSessionSettings);
         //( (System.IDisposable) fixInitiatorApplication ).Dispose();
         //fixInitiatorApplication.Dispose();
         fixInitiatorApplication.LoggedInEvent += HandleFixInitiatorApplicationLoggedInEvent;
         fixInitiatorApplication.LoggedOutEvent += HandleFixInitiatorApplicationLoggedOutEvent;
         fixInitiatorApplication.ReceivedSessionFixMessageEvent += HandleFixInitiatorApplicationReceivedSessionFixMessageEvent;
         fixInitiatorApplication.ReceivedApplicationFixMessageEvent += HandleFixInitiatorApplicationReceivedApplicationFixMessageEvent;
         fixInitiatorApplication.ASyncRepeatedTryLogIn();

         #endregion
         #region

         for(;;)
         {
            System.Threading.Monitor.Exit(Common.Core.Threading.TThreadingHelpers.MainLockable);
            System.Threading.Thread.Sleep(1);
            System.Threading.Monitor.Enter(Common.Core.Threading.TThreadingHelpers.MainLockable);

            if(fixInitiatorApplication.IsLoggedIn)
            {
               break;
            }
            else
            {
            }
         }

         #endregion
         #region

         {
            var newOrderSingleFixMessage = new QuickFix.FIX42.NewOrderSingle();
            newOrderSingleFixMessage.ClOrdID =
               new QuickFix.Fields.ClOrdID
                  //(System.Diagnostics.Stopwatch.GetTimestamp().ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
                  (System.Guid.NewGuid().ToString(@"n"/*, System.Globalization.NumberFormatInfo.InvariantInfo*/));
            newOrderSingleFixMessage.HandlInst = new QuickFix.Fields.HandlInst(QuickFix.Fields.HandlInst.AUTOMATED_EXECUTION_ORDER_PRIVATE_NO_BROKER_INTERVENTION);
            newOrderSingleFixMessage.Symbol = new QuickFix.Fields.Symbol(@"BTC-USD");
            newOrderSingleFixMessage.Side = new QuickFix.Fields.Side(QuickFix.Fields.Side.SELL);
            newOrderSingleFixMessage.OrderQty =
               new QuickFix.Fields.OrderQty
                  (0.01m);
                  //(0.1m);
                  //(99999.00m);
            newOrderSingleFixMessage.OrdType =
               new QuickFix.Fields.OrdType
                  //(QuickFix.Fields.OrdType.LIMIT);
                  (QuickFix.Fields.OrdType.MARKET);
            //newOrderSingleFixMessage.Price =
            //   new QuickFix.Fields.Price
            //      //(0.01m);
            //      (10500.00m);
            //newOrderSingleFixMessage.TimeInForce =
            //   new QuickFix.Fields.TimeInForce
            //      //(QuickFix.Fields.TimeInForce.GOOD_TILL_CANCEL);
            //      //(QuickFix.Fields.TimeInForce.IMMEDIATE_OR_CANCEL);
            //      (QuickFix.Fields.TimeInForce.FILL_OR_KILL);
            fixInitiatorApplication.TrySendFixMessage(newOrderSingleFixMessage);
         }

         #endregion
         #region

         System.Threading.Thread.Sleep(4000);

         #endregion
         #region

         //fixInitiatorApplication.AsyncLogOut();
         fixInitiatorApplication.Dispose();
         //( (System.IDisposable) fixInitiatorApplication ).Dispose();
         System.Threading.Monitor.Exit(Common.Core.Threading.TThreadingHelpers.MainLockable);

         #endregion
      }

      #endregion
      #region {private HandleFixInitiatorApplicationLoggedInEvent}.

      private static void HandleFixInitiatorApplicationLoggedInEvent()
      {
      }

      #endregion
      #region {private HandleFixInitiatorApplicationLoggedOutEvent}.

      private static void HandleFixInitiatorApplicationLoggedOutEvent()
      {
      }

      #endregion
      #region {private HandleFixInitiatorApplicationReceivedSessionFixMessageEvent}.

      private static void HandleFixInitiatorApplicationReceivedSessionFixMessageEvent
         ( QuickFix.Message fixMessage
         )
      {
      }

      #endregion
      #region {private HandleFixInitiatorApplicationReceivedApplicationFixMessageEvent}.

      private static void HandleFixInitiatorApplicationReceivedApplicationFixMessageEvent
         ( QuickFix.Message fixMessage
         )
      {
         if(fixMessage is QuickFix.FIX42.ExecutionReport executionReportFixMessage)
         {
         }
         else
         {
         }
      }

      #endregion
   }
}
