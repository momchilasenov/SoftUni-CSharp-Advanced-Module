using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    class Engine
    {
        private ILogger logger;

        public Engine(ILogger logger)
        {
            this.logger = logger;
        }

        public void Start()
        {
            logger.Log("Game started");
        }

        public void End()
        {
            logger.Log("Game ended");
        }
    }
}
