namespace GdaxPrototyping.Applications.GdaxFixApiFacadePrototype.QuickFixNFacade
{
   /// <summary>
   /// <Comment201704135>
   /// I added some format strings here. I can add more if needed.
   /// Comment201704134 relates.
   /// </Comment201704135>
   /// </summary>
   [ System.Security.SuppressUnmanagedCodeSecurityAttribute() ]
   public static class TFixHelpers
   {
      #region Data.

      /// <summary>
      /// In case the FIX counterparty demands the {TransactTime} or some other FIX field like that,
      /// it's more efficient to send this constant rather than capture and format the current date-time.
      /// See also: {DateTimeInFutureAsMilliSecondResolutionString}.
      /// todo.3 This will not be in the future forever.
      /// todo.3 Release-validate on start that this is still a few years from now.
      /// </summary>
      public const string DateTimeInFutureAsSecondResolutionString = @"20361231-15:41:27";

      /// <summary>
      /// Use this if the FIX counterparty demands milliseconds.
      /// See also: {DateTimeInFutureAsSecondResolutionString}.
      /// </summary>
      public const string DateTimeInFutureAsMilliSecondResolutionString =
         DateTimeInFutureAsSecondResolutionString + @".386";

      public const string DateFormatString = @"yyyyMMdd";
      public const string TimeOfDaySecondResolutionFormatString = @"HH\:mm\:ss";
      public const string TimeOfDayMilliSecondResolutionFormatString =
         TimeOfDaySecondResolutionFormatString + @"\.fff";
      public const string DateTimeSecondResolutionFormatString =
         DateFormatString + @"\-" + TimeOfDaySecondResolutionFormatString;
      public const string DateTimeMilliSecondResolutionFormatString =
         DateFormatString + @"\-" + TimeOfDayMilliSecondResolutionFormatString;

      #endregion
   }
}
