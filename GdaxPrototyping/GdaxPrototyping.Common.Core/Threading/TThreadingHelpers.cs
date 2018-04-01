namespace GdaxPrototyping.Common.Core.Threading
{
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   public static class TThreadingHelpers
   {
      #region Data.

      public static object MainLockable { get; private set; }

      [System.ThreadStaticAttribute()]
      private static System.Threading.Thread CurrentThread_;

      [System.ThreadStaticAttribute()]
      private static int CurrentThreadManagedThreadId_;

      private static readonly bool DataTypeWasInitialized_ = InitializeDataType();

      #endregion

      #region {private InitializeDataType}.

      private static bool InitializeDataType()
      {
         MainLockable =
            //System.AppDomain.CurrentDomain;
            new object();
         return true;
      }

      #endregion

      #region {public InherentlyAtomicGetCurrentThread}.

      public static System.Threading.Thread InherentlyAtomicGetCurrentThread()
      {
         System.Threading.Thread currentThreadCopy = CurrentThread_;

         if(currentThreadCopy is null)
         {
            currentThreadCopy = System.Threading.Thread.CurrentThread;
            CurrentThread_ = currentThreadCopy;
         }
         else
         {
         }

         return currentThreadCopy;
      }

      #endregion
      #region {public CurrentThread}.

      public static System.Threading.Thread CurrentThread
      {
         get
         {
            //System.Diagnostics.Debug.Assert(! (CurrentThread_ is null));
            return CurrentThread_;
         }
      }

      #endregion
      #region {public InherentlyAtomicGetCurrentThreadManagedThreadId}.

      public static int InherentlyAtomicGetCurrentThreadManagedThreadId()
      {
         int currentThreadManagedThreadIdCopy = CurrentThreadManagedThreadId_;

         if(currentThreadManagedThreadIdCopy == 0)
         {
            currentThreadManagedThreadIdCopy = InherentlyAtomicGetCurrentThread().ManagedThreadId;
            CurrentThreadManagedThreadId_ = currentThreadManagedThreadIdCopy;
         }
         else
         {
         }

         return currentThreadManagedThreadIdCopy;
      }

      #endregion
      #region {public CurrentThreadManagedThreadId}.

      public static int CurrentThreadManagedThreadId
      {
         get
         {
            //System.Diagnostics.Debug.Assert(CurrentThreadManagedThreadId_ != 0);
            return CurrentThreadManagedThreadId_;
         }
      }

      #endregion
   }
}
