namespace GdaxPrototyping.Common.Core.Diagnostics
{
   /// <summary>
   /// todo.1 I copied this from "BitCoinArbitrageRobot". A better version could exist elsewhere, possibly in "TotalQuant".
   /// todo.1 Implement alerts.
   /// yg? Does it make sense to rename this to {TMainLogger}?
   /// </summary>
   [ System.Security.SuppressUnmanagedCodeSecurityAttribute() ]
   public static class TLoggingHelpers
   {
      #region Data.

      /// <summary>
      /// <Comment201704221>
      /// The client code should flush this periodically.
      /// </Comment201704221>
      /// </summary>
      public static System.IO.StreamWriter MainLogStreamWriter { get; private set; }

      private static string LogRecordHeaderPart1_;

      #endregion

      #region {public Prepare}.

      public static void Prepare
         ( TLoggingHelpersConfiguration loggingHelpersConfiguration
         )
      {
         CreateMainLogStreamWriter(loggingHelpersConfiguration);
      }

      #endregion

      #region {private CreateMainLogStreamWriter}.

      private static void CreateMainLogStreamWriter
         ( TLoggingHelpersConfiguration loggingHelpersConfiguration
         )
      {
         {
            string mainLogFilePathName;

            {
               string currentUtcDateTimeAsString =
                  System.DateTime.UtcNow.ToString
                     (@"yyyyMMddHHmmss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
               mainLogFilePathName =
                  loggingHelpersConfiguration.MainLogFilePathName.Replace
                     (@"<DateTimeStamp>", currentUtcDateTimeAsString);
            }

            mainLogFilePathName =
               System.IO.Path.Combine
                  (loggingHelpersConfiguration.BaseDirectoryPathName, mainLogFilePathName);

            // todo.2 It could make sense to use an advanced {....FileStream} constructor.
            // todo.2 What about buffer size?
            MainLogStreamWriter =
               new System.IO.StreamWriter
                  ( mainLogFilePathName,
                     true,
                     StaticData.TStaticSingletonObjectContainer< System.Text.UTF8Encoding >.Object
                  );
         }

#if(DEBUG)
         // Comment201704221 relates.
         MainLogStreamWriter.AutoFlush = true;
#endif
      }

      #endregion

      #region {public LogLogRecordHeader}.

      public static void LogLogRecordHeader()
      {
         LogLogRecordHeader(System.DateTime.UtcNow);
      }

      #endregion
      #region {public LogLogRecordHeader}.

      public static void LogLogRecordHeader
         ( System.DateTime currentUtcDateTime
         )
      {
         {
            string currentUtcDateTimeAsString =
               currentUtcDateTime.ToString
                  (@"yyyyMMdd\ HH\:mm\:ss\.ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            MainLogStreamWriter.Write(currentUtcDateTimeAsString);
         }

         {
            string logRecordHeaderPart1Copy = LogRecordHeaderPart1_;

            if(logRecordHeaderPart1Copy is null)
            {
               logRecordHeaderPart1Copy =
                  ((uint) Threading.TThreadingHelpers.InherentlyAtomicGetCurrentThreadManagedThreadId()).ToString(@"\;\ 0\;\ ", System.Globalization.NumberFormatInfo.InvariantInfo);
               LogRecordHeaderPart1_ = logRecordHeaderPart1Copy;
            }
            else
            {
            }

            MainLogStreamWriter.Write(logRecordHeaderPart1Copy);
         }
      }

      #endregion
      #region {public LogLogRecordTrailer}.

      public static void LogLogRecordTrailer()
      {
         MainLogStreamWriter.WriteLine();
      }

      #endregion

      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08,
            string text09,
            string text10
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         MainLogStreamWriter.Write(text09);
         MainLogStreamWriter.Write(text10);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08,
            string text09,
            string text10,
            string text11,
            string text12
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         MainLogStreamWriter.Write(text09);
         MainLogStreamWriter.Write(text10);
         MainLogStreamWriter.Write(text11);
         MainLogStreamWriter.Write(text12);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08,
            string text09,
            string text10,
            string text11,
            string text12,
            string text13,
            string text14,
            string text15,
            string text16,
            string text17,
            string text18
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         MainLogStreamWriter.Write(text09);
         MainLogStreamWriter.Write(text10);
         MainLogStreamWriter.Write(text11);
         MainLogStreamWriter.Write(text12);
         MainLogStreamWriter.Write(text13);
         MainLogStreamWriter.Write(text14);
         MainLogStreamWriter.Write(text15);
         MainLogStreamWriter.Write(text16);
         MainLogStreamWriter.Write(text17);
         MainLogStreamWriter.Write(text18);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08,
            string text09,
            string text10,
            string text11,
            string text12,
            string text13,
            string text14,
            string text15,
            string text16,
            string text17,
            string text18,
            string text19,
            string text20
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         MainLogStreamWriter.Write(text09);
         MainLogStreamWriter.Write(text10);
         MainLogStreamWriter.Write(text11);
         MainLogStreamWriter.Write(text12);
         MainLogStreamWriter.Write(text13);
         MainLogStreamWriter.Write(text14);
         MainLogStreamWriter.Write(text15);
         MainLogStreamWriter.Write(text16);
         MainLogStreamWriter.Write(text17);
         MainLogStreamWriter.Write(text18);
         MainLogStreamWriter.Write(text19);
         MainLogStreamWriter.Write(text20);
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            string text03,
            string text04,
            string text05,
            string text06,
            string text07,
            string text08,
            string text09,
            string text10,
            string text11,
            string text12,
            string text13,
            string text14,
            string text15,
            string text16,
            string text17,
            string text18,
            string text19,
            string text20,
            string text21,
            string text22
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(text03);
         MainLogStreamWriter.Write(text04);
         MainLogStreamWriter.Write(text05);
         MainLogStreamWriter.Write(text06);
         MainLogStreamWriter.Write(text07);
         MainLogStreamWriter.Write(text08);
         MainLogStreamWriter.Write(text09);
         MainLogStreamWriter.Write(text10);
         MainLogStreamWriter.Write(text11);
         MainLogStreamWriter.Write(text12);
         MainLogStreamWriter.Write(text13);
         MainLogStreamWriter.Write(text14);
         MainLogStreamWriter.Write(text15);
         MainLogStreamWriter.Write(text16);
         MainLogStreamWriter.Write(text17);
         MainLogStreamWriter.Write(text18);
         MainLogStreamWriter.Write(text19);
         MainLogStreamWriter.Write(text20);
         MainLogStreamWriter.Write(text21);
         MainLogStreamWriter.Write(text22);
         LogLogRecordTrailer();
      }

      #endregion

      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( System.Exception exception
         )
      {
         LogLogRecord(@"Error; ", exception);
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            System.Exception exception
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(exception.ToString());
         LogLogRecordTrailer();
      }

      #endregion
      #region {public LogLogRecord}.

      public static void LogLogRecord
         ( string text01,
            string text02,
            System.Exception exception
         )
      {
         LogLogRecordHeader();
         MainLogStreamWriter.Write(text01);
         MainLogStreamWriter.Write(text02);
         MainLogStreamWriter.Write(exception.ToString());
         LogLogRecordTrailer();
      }

      #endregion
   }
}
