using System;

namespace WpfChallenge.Models
{
    [Serializable]
    public class NotFoundException : Exception 
    {
        public string Name { get; }
        public NotFoundException() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, Exception inner)
            : base(message, inner) { }

    }
    
}
