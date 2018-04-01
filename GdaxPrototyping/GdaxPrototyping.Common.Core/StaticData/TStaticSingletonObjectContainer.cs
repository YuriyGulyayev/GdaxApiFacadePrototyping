namespace GdaxPrototyping.Common.Core.StaticData
{
   /// <summary>
   /// <Comment201708203>
   /// todo.1 Is this comment referenced anywhere?
   /// yg? Does this belong to the {ObjectModel} {namespace}?
   /// </Comment201708203>
   /// </summary>
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   public static class TStaticSingletonObjectContainer
      < TClass_
      >
      where TClass_ : /*class,*/ new()
   {
      public static readonly TClass_ Object = new TClass_();
   }
}
