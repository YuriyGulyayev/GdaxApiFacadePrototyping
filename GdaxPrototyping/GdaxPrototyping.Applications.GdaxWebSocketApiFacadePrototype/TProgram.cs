namespace GdaxPrototyping.Applications.GdaxWebSocketApiFacadePrototype
{
   [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
   internal static class TProgram
   {
      private static bool StaticBool1_;

      private static void Main
         ( //string[] arguments
         )
      {
         // todo await ???
         Prototype201802084();

         do
         {
            System.Threading.Thread.Sleep(1);
         }
         while(! StaticBool1_);
      }

      private static async void Prototype201802084()
      {
         await Prototype201802084_1().ConfigureAwait(false);
      }

      private static async System.Threading.Tasks.Task Prototype201802084_1()
      {
         // todo We need exception handling here.

         {
            double dateTimeFrequencyToPhaseFrequencyRatio =
               (double) System.TimeSpan.TicksPerSecond / (double) System.Diagnostics.Stopwatch.Frequency;
            long basePhase = System.Diagnostics.Stopwatch.GetTimestamp();
            long baseUtcDateTimeInTicks = System.DateTime.UtcNow.Ticks;
            basePhase = System.Diagnostics.Stopwatch.GetTimestamp();
            baseUtcDateTimeInTicks = System.DateTime.UtcNow.Ticks;

            var clientWebSocket = new System.Net.WebSockets.ClientWebSocket();
            //System.Threading.Tasks.Task task =
            await
               clientWebSocket.ConnectAsync
                  ( new System.Uri
                        //(@"wss://ws-feed-public.sandbox.gdax.com"),
                        (@"wss://ws-feed.gdax.com"),
                     System.Threading.CancellationToken.None
                  );

               // todo ??? The caller really should do this if needed.
               // todo ??? But any method really should do this
               // todo ??? if after {await} it's not supposed to return to the synchronization context.
               //// todo Comment in other places where we don't call this.
               //.ConfigureAwait(false);
            //int timeSpanInMilliSeconds = System.Environment.TickCount;

            // todo Remember to call this even if the task already completed -- to rethrow any exceptions.
            // todo {task.Result} also waits, right?
            //task.Wait();

            //task.RunSynchronously();
            //timeSpanInMilliSeconds = System.Environment.TickCount - timeSpanInMilliSeconds;

            //>>>clientWebSocket.ReceiveAsync

            if(clientWebSocket.State == System.Net.WebSockets.WebSocketState.Open)
            {
               // todo Prototype subscribe/unsubscribe for 1 instrument at a time.

               const string channelName =
                  //@"heartbeat";
                  //@"ticker";
                  @"level2";
                  //@"user";
                  //@"matches";
                  //@"full";

               const string requestString =
                  //Newtonsoft.Json.JsonConvert.SerializeObject
                  //   ( new
                  //      {
                  //         type = "subscribe",
                  //         product_ids = new string[] { @"ETH-USD", @"ETH-EUR", },
                  //      }
                  //   );
                  "{" +
                     "\"type\":\"subscribe\"," +
                     "\"channels\":[{\"name\":\"" + channelName + "\",\"product_ids\":[\"BTC-USD\",\"BTC-EUR\"]}]" +
                  "}";

               byte[] requestBytes = System.Text.Encoding.ASCII.GetBytes(requestString);
               await clientWebSocket.SendAsync
                  ( new System.ArraySegment<byte>(requestBytes),

                     // todo ??? Binary didn't work, right?
                     System.Net.WebSockets.WebSocketMessageType.Text,
                     //System.Net.WebSockets.WebSocketMessageType.Binary,

                     true,
                     System.Threading.CancellationToken.None
                  );

               // todo This really doesn't need to be more than 16K, right?
               var receiveBuffer = new System.ArraySegment<byte>(new byte[33 * 1024]);

               for(bool isMessageBegin = true; ;)
               {
                  if(clientWebSocket.State != System.Net.WebSockets.WebSocketState.Open)
                  {
                     System.Console.WriteLine(@"201802085");
                     break;
                  }
                  else
                  {
                  }

                  System.Net.WebSockets.WebSocketReceiveResult webSocketReceiveResult =
                     await clientWebSocket.ReceiveAsync(receiveBuffer, System.Threading.CancellationToken.None);

                  // todo ???
                  if(webSocketReceiveResult.Count <= 0)
                  {
                     System.Console.WriteLine(@"201802086");
                     break;
                  }
                  else
                  {
                  }

                  if(isMessageBegin)
                  {
                     isMessageBegin = false;
                     System.Console.WriteLine(',');
                     //System.Console.WriteLine();
                     long currentUtcDateTimeInTicks =
                        (long) ((double) (ulong) (System.Diagnostics.Stopwatch.GetTimestamp() - basePhase) * dateTimeFrequencyToPhaseFrequencyRatio + 0.5) +
                        baseUtcDateTimeInTicks;
                     System.Console.Write
                        ((new System.DateTime(currentUtcDateTimeInTicks)).ToString(@"o", System.Globalization.DateTimeFormatInfo.InvariantInfo));
                  }
                  else
                  {
                  }

                  string string1 =
                     System.Text.Encoding.ASCII.GetString(receiveBuffer.Array, 0, webSocketReceiveResult.Count);
                  System.Console.Write(string1);

                  if(webSocketReceiveResult.MessageType == System.Net.WebSockets.WebSocketMessageType.Close)
                  {
                     System.Console.WriteLine(@"201802087");
                     break;
                  }
                  else
                  {
                  }

                  if(webSocketReceiveResult.EndOfMessage)
                  {
                     isMessageBegin = true;
                     //break;
                  }
                  else
                  {
                  }
               }
            }
            else
            {
               System.Console.WriteLine(@"201802088");
            }

            // todo ??? WebSocketState >= CloseSent

            clientWebSocket.Dispose();
         }

         StaticBool1_ = true;
      }
   }
}
