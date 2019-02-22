using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedwayManagerWebAPI.Persistence
{
    public class ContextInitializer
    {
        public static void Initialize(Context context)
        {
            var initializer = new ContextInitializer();
            initializer.Seed(context);
        }

        private void Seed(Context context)
        {
            
        }
    }
}
