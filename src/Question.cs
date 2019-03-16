﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Makaretu.Dns
{
    /// <summary>
    ///   A question about a domain name to resolve.
    /// </summary>
    public class Question : DnsObject
    {
        /// <summary>
        ///    A domain name to query.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///    A two octet code which specifies the type of the query.
        /// </summary>
        /// <value>
        ///    One of the <see cref="DnsType"/> values.
        /// </value>
        /// <remarks>
        ///    The values for this field include all codes valid for a
        ///    TYPE field, together with some more general codes which
        ///    can match more than one type of the resource record.
        /// </remarks>
        public DnsType Type { get; set; }

        /// <summary>
        ///   A two octet code that specifies the class of the query.
        /// </summary>
        /// <value>
        ///   Defaults to <see cref="DnsClass.IN"/>.
        /// </value>
        public DnsClass Class { get; set; } = DnsClass.IN;

        /// <inheritdoc />
        public override IWireSerialiser Read(WireReader reader)
        {
            Name = reader.ReadDomainName();
            Type = (DnsType)reader.ReadUInt16();
            Class = (DnsClass)reader.ReadUInt16();

            return this;
        }

        /// <inheritdoc />
        public override void Write(WireWriter writer)
        {
            writer.WriteDomainName(Name);
            writer.WriteUInt16((ushort)Type);
            writer.WriteUInt16((ushort)Class);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append(Name);
            s.Append(' ');
            s.Append(Class);
            s.Append(' ');
            s.Append(Type);
            return s.ToString();
        }
    }
}
