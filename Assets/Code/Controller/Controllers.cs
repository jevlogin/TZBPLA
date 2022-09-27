using System;
using System.Collections.Generic;


namespace WORLDGAMEDEVELOPMENT
{
    public sealed class Controllers : IInitialization, IExecute, ICleanup, IDisposable
    {
        #region Fields

        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IDisposable> _disposableControllers;

        #endregion


        #region ClassLifeCycles

        public Controllers()
        {
            _executeControllers = new List<IExecute>();
            _initializationControllers = new List<IInitialization>();
            _cleanupControllers = new List<ICleanup>();
            _disposableControllers = new List<IDisposable>();
        }

        #endregion


        #region Methods

        public Controllers Add(IController controller)
        {
            if (controller is IInitialization initialization)
            {
                _initializationControllers.Add(initialization);
            }
            if (controller is IExecute execute)
            {
                _executeControllers.Add(execute);
            }
            if (controller is ICleanup cleanup)
            {
                _cleanupControllers.Add(cleanup);
            }
            if (controller is IDisposable disposable)
            {
                _disposableControllers.Add(disposable);
            }
            return this;
        }

        #endregion


        #region ICleanup

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupControllers.Count; i++)
            {
                _cleanupControllers[i].Cleanup();
            }
        }

        #endregion


        #region IDispose

        public void Dispose()
        {
            for (int i = 0; i < _disposableControllers.Count; i++)
            {
                _disposableControllers[i].Dispose();
            }
        }

        #endregion


        #region IExecute

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executeControllers.Count; i++)
            {
                _executeControllers[i].Execute(deltaTime);
            }
        }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            for (int i = 0; i < _initializationControllers.Count; i++)
            {
                _initializationControllers[i].Initialization();
            }
        }

        #endregion
    }
}