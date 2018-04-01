namespace GdaxPrototyping.Common.Core.ObjectModel
{
   /// <summary>
   /// <Comment201704154>
   /// yg? Unlike {System.Action}, this {delegate} is not contravariant.
   /// </Comment201704154>
   /// </summary>
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   public delegate void TInsecureAction();

   /// <summary>
   /// yg? Comment201704154 applies.
   /// </summary>
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   public delegate void TInsecureAction
      < TArgument1_
      >
      ( TArgument1_ argument1
      );

   /// <summary>
   /// yg? Comment201704154 applies.
   /// </summary>
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   public delegate void TInsecureAction
      < TArgument1_,
          TArgument2_
      >
      ( TArgument1_ argument1,
         TArgument2_ argument2
      );
}
