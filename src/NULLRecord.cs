﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Makaretu.Dns
{
    /// <summary>
    ///   A null RR (EXPERIMENTAL).
    /// </summary>
    /// <remarks>
    ///  NULL records cause no additional section processing.  NULL RRs are not
    ///  allowed in master files.NULLs are used as placeholders in some
    ///  experimental extensions of the DNS.
    /// </remarks>
    public class NULLRecord : ResourceRecord
    {
        /// <summary>
        ///   Creates a new instance of the <see cref="NULLRecord"/> class.
        /// </summary>
        public NULLRecord() : base()
        {
            Type = 10;
        }

        /// <summary>
        ///    Specfic data for the resource.
        /// </summary>
        public byte[] Data { get; set; }


        /// <inheritdoc />
        protected override void ReadData(DnsReader reader, int length)
        {
            Data = reader.ReadBytes(length);
        }

        /// <inheritdoc />
        protected override void WriteData(DnsWriter writer)
        {
            writer.WriteBytes(Data);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var that = obj as NULLRecord;
            if (that == null) return false;

            return base.Equals(obj) 
                && this.Data.SequenceEqual(that.Data);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return base.GetHashCode()
                ^ Data?.Sum(b => b).GetHashCode() ?? 0;
        }

    }
}
