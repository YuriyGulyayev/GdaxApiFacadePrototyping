using System;
using System.Collections.Generic;

namespace QuickFix
{
    // v2 TODO - consider making this internal
    /// <summary>
    /// Used by the session communications code. Not intended to be used by applications.
    /// </summary>
    public class SessionState : IDisposable
    {
        #region Private Members

        //private object sync_ = new object();
        private bool isEnabled_ = true;
        private bool receivedLogon_ = false;
        private bool receivedReset_ = false;
        private bool sentLogon_ = false;
        private bool sentLogout_ = false;
        private bool sentReset_ = false;
        private string logoutReason_ = "";
        private int testRequestCounter_ = 0;
        private int heartBtInt_ = 0;
        private int heartBtIntAsMilliSecs_ = 0;
        private DateTime lastReceivedTimeDT_ = DateTime.MinValue;
        private DateTime lastSentTimeDT_ = DateTime.MinValue;
        private int logonTimeout_ = 10;
        private long logonTimeoutAsMilliSecs_ = 10 * 1000;
        private int logoutTimeout_ = 2;
        private long logoutTimeoutAsMilliSecs_ = 2 * 1000;
        private ResendRange resendRange_ = new ResendRange();
        private Dictionary<int, Message> msgQueue = new Dictionary<int, Message>();

        private ILog log_;

        #endregion

        #region Unsynchronized Properties

        public IMessageStore MessageStore
        { get; set; }

        public bool IsInitiator
        { get; set; }

        public bool ShouldSendLogon
        { get { return IsInitiator && !SentLogon; } }

        public ILog Log
        { get { return log_; } }

        #endregion

        #region Synchronized Properties

        public bool IsEnabled
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return isEnabled_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { isEnabled_ = value; } }
        }

        public bool ReceivedLogon
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return receivedLogon_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { receivedLogon_ = value; } }
        }

        public bool ReceivedReset
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return receivedReset_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { receivedReset_ = value; } }
        }

        public bool SentLogon
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return sentLogon_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { sentLogon_ = value; } }
        }

        public bool SentLogout
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return sentLogout_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { sentLogout_ = value; } }
        }

        public bool SentReset
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return sentReset_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { sentReset_ = value; } }
        }

        public string LogoutReason
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return logoutReason_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { logoutReason_ = value; } }
        }

        public int TestRequestCounter
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return testRequestCounter_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { testRequestCounter_ = value; } }
        }

        public int HeartBtInt
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return heartBtInt_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { heartBtInt_ = value; heartBtIntAsMilliSecs_ = 1000 * value; } }
        }

        public int HeartBtIntAsMilliSecs
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return heartBtIntAsMilliSecs_; } }
        }

        public DateTime LastReceivedTimeDT
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return lastReceivedTimeDT_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { lastReceivedTimeDT_ = value; } }
        }


        public DateTime LastSentTimeDT
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return lastSentTimeDT_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { lastSentTimeDT_ = value; } }
        }

        public int LogonTimeout
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return logonTimeout_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { logonTimeout_ = value; logonTimeoutAsMilliSecs_ = 1000 * value; } }
        }

        public long LogonTimeoutAsMilliSecs
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return logonTimeoutAsMilliSecs_; } }
        }

        public int LogoutTimeout
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return logoutTimeout_; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { logoutTimeout_ = value; logoutTimeoutAsMilliSecs_ = 1000 * value; } }
        }

        public long LogoutTimeoutAsMilliSecs
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return logoutTimeoutAsMilliSecs_; } }
        }

        private Dictionary<int, Message> MsgQueue
        {
            get { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return msgQueue; } }
            set { lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { msgQueue = value; } }
        }

        #endregion

        public SessionState(ILog log, int heartBtInt)
        {
            log_ = log;
            this.HeartBtInt = heartBtInt;
            this.IsInitiator = (0 != heartBtInt);
            lastReceivedTimeDT_ = DateTime.UtcNow;
            lastSentTimeDT_ = DateTime.UtcNow;
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system time</param>
        /// <param name="lastReceivedTime">last received time</param>
        /// <param name="logonTimeout">number of milliseconds to wait for a Logon from the counterparty</param>
        /// <returns></returns>
        public static bool LogonTimedOut(DateTime now, long logonTimeout, DateTime lastReceivedTime)
        {
            return (now.Subtract(lastReceivedTime).TotalMilliseconds) >= logonTimeout;
        }
        public bool LogonTimedOut()
        {
            return LogonTimedOut(DateTime.UtcNow, this.LogonTimeoutAsMilliSecs, this.LastReceivedTimeDT);
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system datetime</param>
        /// <param name="heartBtIntMillis">heartbeat interval in milliseconds</param>
        /// <param name="lastReceivedTime">last received datetime</param>
        /// <returns>true if timed out</returns>
        public static bool TimedOut(DateTime now, int heartBtIntMillis, DateTime lastReceivedTime)
        {
            double elapsed = now.Subtract(lastReceivedTime).TotalMilliseconds;
            return elapsed >= (2.4 * heartBtIntMillis);
        }
        public bool TimedOut()
        {
            return TimedOut(DateTime.UtcNow, this.HeartBtIntAsMilliSecs, this.LastReceivedTimeDT);
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system time</param>
        /// <param name="sentLogout">true if a Logout has been sent to the counterparty, otherwise false</param>
        /// <param name="logoutTimeout">number of milliseconds to wait for a Logout from the counterparty</param>
        /// <param name="lastSentTime">last sent time</param>
        /// <returns></returns>
        public static bool LogoutTimedOut(DateTime now, bool sentLogout, long logoutTimeout, DateTime lastSentTime)
        {
            return sentLogout && ((now.Subtract(lastSentTime).TotalMilliseconds) >= logoutTimeout);
        }
        public bool LogoutTimedOut()
        {
            return LogoutTimedOut(DateTime.UtcNow, this.SentLogout, this.LogoutTimeoutAsMilliSecs, this.LastSentTimeDT);
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system time</param>
        /// <param name="heartBtIntMillis">heartbeat interval in milliseconds</param>
        /// <param name="lastReceivedTime">last received time</param>
        /// <param name="testRequestCounter">test request counter</param>
        /// <returns>true if test request is needed</returns>
        public static bool NeedTestRequest(DateTime now, int heartBtIntMillis, DateTime lastReceivedTime, int testRequestCounter)
        {
            double elapsedMilliseconds = now.Subtract(lastReceivedTime).TotalMilliseconds;
            return elapsedMilliseconds >= (1.2 * ((testRequestCounter + 1) * heartBtIntMillis));
        }
        public bool NeedTestRequest()
        {
            return NeedTestRequest(DateTime.UtcNow, this.HeartBtIntAsMilliSecs, this.LastReceivedTimeDT, this.TestRequestCounter);
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system time</param>
        /// <param name="heartBtIntMillis">heartbeat interval in milliseconds</param>
        /// <param name="lastSentTime">last sent time</param>
        /// <param name="testRequestCounter">test request counter</param>
        /// <returns>true if heartbeat is needed</returns>
        public static bool NeedHeartbeat(DateTime now, int heartBtIntMillis, DateTime lastSentTime, int testRequestCounter)
        {
            double elapsed = now.Subtract(lastSentTime).TotalMilliseconds;
            return (elapsed >= Convert.ToDouble(heartBtIntMillis)) && (0 == testRequestCounter);
        }
        public bool NeedHeartbeat()
        {
            return NeedHeartbeat(DateTime.UtcNow, this.HeartBtIntAsMilliSecs, this.LastSentTimeDT, this.TestRequestCounter);
        }

        /// <summary>
        /// All time args are in milliseconds
        /// </summary>
        /// <param name="now">current system time</param>
        /// <param name="heartBtIntMillis">heartbeat interval in milliseconds</param>
        /// <param name="lastSentTime">last sent time</param>
        /// <param name="lastReceivedTime">last received time</param>
        /// <returns>true if within heartbeat interval</returns>
        public static bool WithinHeartbeat(DateTime now, int heartBtIntMillis, DateTime lastSentTime, DateTime lastReceivedTime)
        {
            return ((now.Subtract(lastSentTime).TotalMilliseconds) < Convert.ToDouble(heartBtIntMillis))
                && ((now.Subtract(lastReceivedTime).TotalMilliseconds) < Convert.ToDouble(heartBtIntMillis));
        }
        public bool WithinHeartbeat()
        {
            return WithinHeartbeat(DateTime.UtcNow, this.HeartBtIntAsMilliSecs, this.LastSentTimeDT, this.LastReceivedTimeDT);
        }

        public ResendRange GetResendRange()
        {
            return resendRange_;
        }

        public void Get(int begSeqNo, int endSeqNo, List<string> messages)
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable)
            {
              MessageStore.Get(begSeqNo, endSeqNo, messages);
            }
        }

        public void SetResendRange(int begin, int end)
        {
            SetResendRange(begin, end, -1);
        }

        public void SetResendRange(int begin, int end, int chunkEnd)
        {
            resendRange_.BeginSeqNo = begin;
            resendRange_.EndSeqNo = end;
            resendRange_.ChunkEndSeqNo = chunkEnd == -1 ? end : chunkEnd;
        }

        public bool ResendRequested()
        {
            return !(resendRange_.BeginSeqNo == 0 && resendRange_.EndSeqNo == 0);
        }

        public void Queue(int msgSeqNum, Message msg)
        {
            MsgQueue.Add(msgSeqNum, msg);
        }

        public void ClearQueue()
        {
            MsgQueue.Clear();
        }

        public QuickFix.Message Dequeue(int num)
        {
            if (MsgQueue.ContainsKey(num))
            {
                QuickFix.Message msg = MsgQueue[num];
                MsgQueue.Remove(num);
                return msg;
            }
            return null;
        }

        public Message Retrieve(int msgSeqNum)
        {
            Message msg = null;
            if (MsgQueue.ContainsKey(msgSeqNum))
            {
                msg = MsgQueue[msgSeqNum];
                MsgQueue.Remove(msgSeqNum);
            }
            return msg;
        }

        /// <summary>
        /// All time values are displayed in milliseconds.
        /// </summary>
        /// <returns>a string that represents the session state</returns>
        public override string ToString()
        {
            return new System.Text.StringBuilder("SessionState ")
                .Append("[ Now=").Append(DateTime.UtcNow)
                .Append(", HeartBtInt=").Append(this.HeartBtIntAsMilliSecs)
                .Append(", LastSentTime=").Append(this.LastSentTimeDT)
                .Append(", LastReceivedTime=").Append(this.LastReceivedTimeDT)
                .Append(", TestRequestCounter=").Append(this.TestRequestCounter)
                .Append(", WithinHeartbeat=").Append(WithinHeartbeat())
                .Append(", NeedHeartbeat=").Append(NeedHeartbeat())
                .Append(", NeedTestRequest=").Append(NeedTestRequest())
                .Append(", ResendRange=").Append(GetResendRange())
                .Append(" ]").ToString();

        }

        #region MessageStore-manipulating Members

        public bool Set(int msgSeqNum, string msg)
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return this.MessageStore.Set(msgSeqNum, msg); }
        }

        public int GetNextSenderMsgSeqNum()
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return this.MessageStore.GetNextSenderMsgSeqNum(); }
        }

        public int GetNextTargetMsgSeqNum()
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return this.MessageStore.GetNextTargetMsgSeqNum(); }
        }

        public void SetNextSenderMsgSeqNum(int value)
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { this.MessageStore.SetNextSenderMsgSeqNum(value); }
        }

        public void SetNextTargetMsgSeqNum(int value)
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { this.MessageStore.SetNextTargetMsgSeqNum(value); }
        }

        public void IncrNextSenderMsgSeqNum()
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { this.MessageStore.IncrNextSenderMsgSeqNum(); }
        }

        public void IncrNextTargetMsgSeqNum()
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { this.MessageStore.IncrNextTargetMsgSeqNum(); }
        }

        public System.DateTime? CreationTime
        {
            get
            {
                lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { return this.MessageStore.CreationTime; }
            }
        }

        [Obsolete("Use Reset(reason) instead.")]
        public void Reset()
        {
            this.Reset("(unspecified reason)");
        }
        
        public void Reset(string reason)
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable)
            {
                this.MessageStore.Reset();
                this.Log.OnEvent("Session reset: " + reason);
            }
        }

        public void Refresh()
        {
            lock (GdaxPrototyping.Common.Core.Threading.TThreadingHelpers.MainLockable) { this.MessageStore.Refresh(); }
        }

        #endregion

        public void Dispose()
        {
            if (log_ != null) { log_.Dispose(); }
            if (MessageStore != null) { MessageStore.Dispose(); }
        }
    }
}

