// todo.1 Carve out QuickFIX/n facade from here.



// {QuickFix.AbstractInitiator}.
//    Implements {QuickFix.IInitiator}.
// // {QuickFix.AbstractInitiator.IsLoggedOn}.
// // {QuickFix.AbstractInitiator.Dispose}.
// //    This calls {Stop}.
// //    yg? So it's currently unnecessary to call this.
// //    Comment201704204 applies.
// {QuickFix.AbstractInitiator.Start}.
//    This appears to be asynchronous and thread unsafe.
// {QuickFix.AbstractInitiator.Stop}.
//    <Comment201704204>
//    This appears to be blocking and thread unsafe.
//    This is safe to call redundantly.
//    We call the parameterless overload of this. The other overload could be toublesome.
//    This blocks and waits for other threads to complete,
//    therefore this probably must not be called from within a critical section
//    because the other threads will probably have a chance to deadlock.
//    </Comment201704204>

// {QuickFix.IApplication}.
// {QuickFix.IApplication.OnCreate}.
// {QuickFix.IApplication.OnLogon}.
//    <Comment201704152>
//    yg? In some marginal cases, when {QuickFix.Session.LookupSession} is called from here,
//    yg? it can return {null}.
//    </Comment201704152>
// {QuickFix.IApplication.OnLogout}.
//    On log in error, this will be called even though {OnLogon} wasn't called.
// {QuickFix.IApplication.ToAdmin}.
//    <Comment201704207>
//    Do not {throw} {QuickFix.DoNotSend} from here.
//    </Comment201704207>
// {QuickFix.IApplication.ToApp}.
// {QuickFix.IApplication.FromAdmin}.
// {QuickFix.IApplication.FromApp}.

// // {QuickFix.IApplicationExt}.

// // {QuickFix.DataDictionary....}.

// // {QuickFix.DataDictionaryProvider}.

// {QuickFix.DefaultMessageFactory}.

// // {QuickFix.Dictionary}.

// {QuickFix.DoNotSend}.
//    Derived from {QuickFix.QuickFIXException}.
//    Comment201704207 relates.

// {QuickFix.FieldMap}.
//    Implements {System.IEnumerable<>}.
// // {QuickFix.FieldMap.FieldMap}.
// // {QuickFix.FieldMap.FieldOrder}.
// {QuickFix.FieldMap.AddGroup}.
//    This clones the whole group, which is inefficient.
// {QuickFix.FieldMap.GetBoolean}.
// {QuickFix.FieldMap.GetChar}.
// {QuickFix.FieldMap.GetDateOnly}.
// {QuickFix.FieldMap.GetDateTime}.
// {QuickFix.FieldMap.GetDecimal}.
// {QuickFix.FieldMap.GetField}.
//    Comment201704163 relates and/or applies.
// {QuickFix.FieldMap.GetGroup}.
//    <Comment201704164>
//    Group index is 1-based.
//    </Comment201704164>
// {QuickFix.FieldMap.GetInt}.
// {QuickFix.FieldMap.GetString}.
//    <Comment201704163>
//    This is probably faster than {GetField} unless the field doesn't exist and an exception is going to be thrown.
//    </Comment201704163>
// {QuickFix.FieldMap.GetTimeOnly}.
// {QuickFix.FieldMap.IsSetField}.
// {QuickFix.FieldMap.RemoveField}.
// {QuickFix.FieldMap.RemoveGroup}.
//    Comment201704164 applies.
// {QuickFix.FieldMap.ReplaceGroup}.
//    Comment201704164 applies.
// {QuickFix.FieldMap.SetField}.
//    <ToDo201704082.3>
//    This is not available for {long}, {ulong}, {uint}, {double}, but I can implement those field types myself.
//    </ToDo201704082.3>
// // {QuickFix.FieldMap.SetFields}.

// // {QuickFix.Fields.Converters....}.
// //    <Comment201704134>
// //    Some {class}es here contain some format strings, although some are inefficient and/or imperfect.
// //    </Comment201704134>

// {QuickFix.Fields.BooleanField}.
//    Derived from {FieldBase<>}.

// {QuickFix.Fields.CharField}.
//    Derived from {FieldBase<>}.

// {QuickFix.Fields.CumQty} and other standard FIX fields.

// {QuickFix.Fields.DateTimeField}.
//    Derived from {FieldBase<>}.

// {QuickFix.Fields.DecimalField}.
//    Derived from {FieldBase<>}.
//    ToDo201704082.3 applies.

// {QuickFix.Fields.IField}.

// {QuickFix.Fields.FieldBase<>}.
//    Implements {QuickFix.Fields.IField}.

// {QuickFix.Fields.IntField}.
//    Derived from {FieldBase<>}.
//    ToDo201704082.3 applies.

// {QuickFix.Fields.StringField}.
//    Derived from {FieldBase<>}.

// {QuickFix.Fields.Tags}.

// {QuickFix.FieldNotFoundException}.
//    Derived from {System.ApplicationException}.

// {QuickFix.FileStoreFactory}.
//    Implements {QuickFix.IMessageStoreFactory}.

// {QuickFix.FIX44.NewOrderSingle} and other standard FIX messages.

// {QuickFix.Group}.
//    Derived from {QuickFix.FieldMap}.
//    In most cases we use a derived {class} of this.
//    Comment201704164 relates.
// {QuickFix.Group.Group}.

// // {QuickFix.IInitiator}.
// //    Derived from {System.IDisposable}.

// {QuickFix.ILog}.

// {QuickFix.ILogFactory}.

// {QuickFix.MemoryStoreFactory}.
//    Implements {QuickFix.IMessageStoreFactory}.

// {QuickFix.Message}.
//    Derived from {QuickFix.FieldMap}.
//    In most cases we use a derived {class} of this.
// {QuickFix.Message.Header}.
// {QuickFix.Message.GetFieldOrDefault}.
// // {QuickFix.Message.ToString}.

// // {QuickFix.IMessageStoreFactory}.

// // {QuickFix.QuickFIXException}.
// //    Derived from {System.Exception}.

// // {QuickFix.ScreenLogFactory}.
// //    Implements {QuickFix.ILogFactory}.
// //    This can be useful for prototyping only.

// {QuickFix.Session}.
//    Implements {System.IDisposable}.
// // {QuickFix.Session.Session}.
// // {QuickFix.Session.IsLoggedOn}.
// {QuickFix.Session.LookupSession}.
//    yg? Comment201704152 relates and/or applies.
// // {QuickFix.Session.Dispose}.
// // {QuickFix.Session.Logon}.
// // {QuickFix.Session.Logout}.
// //    We can call this on session create to prevent auto-logon,
// //    which would allow us to have multiple sessions per initiator, which we probably don't actually need.
// // {QuickFix.Session.SendToTarget}.
// //    This method appears to be unnecessary and/or inefficient.
// {QuickFix.Session.Send}.
//    <Comment201704088>
//    This appears to be thread safe.
//    This returns {false} on error.
//    One possible error is when {....DoNotSend} was thrown, which is the only case
//    when the message will not be saved for further resend.
//    Note that it's our code contract to not attempt to send anything while not logged in,
//    so nothing is supposed to be saved for further resend,
//    so it's better to disable resends by configuring {PersistMessages=N}.
//    It appears that this throws {....IOException} on socket error.
//    Otherwise this doesn't appear to throw an exception under any other conditions,
//    including if the connection is not present.
//    yg? I haven't actually researched what will happen on a message store error.
//    yg? Comment201704084 relates.
//    yg? Comment201704083 relates.
//    </Comment201704088>

// {QuickFix.SessionID}.

// // {QuickFix.SessionSchedule}.

// {QuickFix.SessionSettings}
//    yg? Currently, we load this from an ugly ".ini" file.
//    yg? Instead, it could make sense to load this from a {CDATA} in the XML.
//    yg? {....StringReader} could be helpful to imlpement that.
// {QuickFix.SessionSettings.SessionSettings}

// {QuickFix.Transport.SocketInitiator}.
//    Derived from {QuickFix.AbstractInitiator}.
// {QuickFix.Transport.SocketInitiator.SocketInitiator}.
// // {QuickFix.Transport.SocketInitiator.Connected}.
