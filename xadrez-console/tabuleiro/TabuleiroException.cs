using System;

namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        #region CTOR
        public TabuleiroException(string msg)
            : base(msg)
        {

        }
        #endregion
    }
}
