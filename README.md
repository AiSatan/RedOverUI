# RedOverUI

https://www.nuget.org/packages/Red.RedOverUI


# Example

You can look "test project" to see how work with the library

```csharp
            
            //there is you can use the "g" (Graphics object) for draw something on the screen
            RedOverlay.OnUpdate += g =>
            {
                g.FillRectangle(Brushes.Red, new Rectangle(0, 0, 10, 10));
            };
            
            // you should call the Refresh method in "while" cicle for update screen
            while(isRun)
            {
              RedOverlay.Refresh();
              Thread.Sleep(100);
            }
            
            //or you can use this
            var timer = new Timer(500);
            timer.Elapsed += (sender, e) => RedOverlay.Refresh();
            
            
            //then if you done use this method
            RedOverlay.Shutdown();
```

You can read more about the "g" here: https://msdn.microsoft.com/ru-ru/library/system.drawing.graphics_methods(v=vs.110).aspx            
