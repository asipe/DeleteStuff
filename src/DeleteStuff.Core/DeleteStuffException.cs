using System;
using System.Runtime.Serialization;

namespace DeleteStuff.Core {
  public class DeleteStuffException : Exception {
    internal DeleteStuffException() {}
    internal DeleteStuffException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    internal DeleteStuffException(string msg) : base(msg) {}
    internal DeleteStuffException(string msg, Exception e) : base(msg, e) {}
    internal DeleteStuffException(string msg, params object[] fmt) : base(string.Format(msg, fmt)) {}
  }
}