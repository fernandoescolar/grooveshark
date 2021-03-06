﻿using System;
using System.IO;

namespace GrooveSharp.DataTransferObjects
{
    public class GrooveStream: Stream
    {
        private readonly Stream baseStream;

        private readonly long length = 0;

        public override long Length
        {
            get { return length; }
        }

        public GrooveStream(Stream baseStream, long length) : base()
        {
            this.baseStream = baseStream;
            this.length = length;
        }

        #region Stream members

        public override void Write(byte[] buffer, int offset, int count)
        {
            baseStream.Write(buffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return baseStream.Read(buffer, offset, count);
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return baseStream.BeginRead(buffer, offset, count, callback, state);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return baseStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void SetLength(long value)
        {
            baseStream.SetLength(value);
        }

        public override void Flush()
        {
            baseStream.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return baseStream.Seek(offset, origin);
        }

        public override long Position
        {
            get
            {
                return baseStream.Position;
            }
            set
            {
                baseStream.Position = value;
            }
        }

        public override bool CanWrite
        {
            get { return baseStream.CanWrite; }
        }

        public override bool CanSeek
        {
            get { return baseStream.CanSeek; }
        }

        public override bool CanRead
        {
            get { return baseStream.CanRead; }
        }

        public override bool CanTimeout
        {
            get
            {
                return baseStream.CanTimeout;
            }
        }

        public override void Close()
        {
            baseStream.Close();
            base.Close();
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            return baseStream.EndRead(asyncResult);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            baseStream.EndWrite(asyncResult);
        }

        public override int ReadTimeout
        {
            get
            {
                return baseStream.ReadTimeout;
            }
            set
            {
                baseStream.ReadTimeout = value;
            }
        }

        public override int WriteTimeout
        {
            get
            {
                return baseStream.WriteTimeout;
            }
            set
            {
                baseStream.WriteTimeout = value;
            }
        }

        public override int ReadByte()
        {
            return baseStream.ReadByte();
        }

        public override void WriteByte(byte value)
        {
            baseStream.WriteByte(value);
        }

        public override string ToString()
        {
            return baseStream.ToString();
        }

        #endregion
    }
}
