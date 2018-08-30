﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Makaretu.Dns
{
    /// <summary>
    ///   Host information. 
    /// </summary>
    /// <remarks>
    ///   Standard values for CPU and OS can be found in [RFC-1010].
    ///
    ///   HINFO records are used to acquire general information about a host. The
    ///   main use is for protocols such as FTP that can use special procedures
    ///   when talking between machines or operating systems of the same type.
    /// </remarks>
    public class HINFORecord : ResourceRecord
    {
        /// <summary>
        ///   Creates a new instance of the <see cref="HINFORecord"/> class.
        /// </summary>
        public HINFORecord() : base()
        {
            Type = DnsType.HINFO;
            TTL = ResourceRecord.DefaultHostTTL;
        }

        /// <summary>
        ///  CPU type.
        /// </summary>
        public string Cpu { get; set; }

        /// <summary>
        ///  Operating system type.
        /// </summary>
        public string OS { get; set; }


        /// <inheritdoc />
        public override void ReadData(WireReader reader, int length)
        {
            Cpu = reader.ReadString();
            OS = reader.ReadString();
        }

        /// <inheritdoc />
        public override void ReadData(MasterReader reader)
        {
            Cpu = reader.ReadString();
            OS = reader.ReadString();
        }

        /// <inheritdoc />
        public override void WriteData(WireWriter writer)
        {
            writer.WriteString(Cpu);
            writer.WriteString(OS);
        }

        /// <inheritdoc />
        public override void WriteData(TextWriter writer)
        {
            writer.Write(Cpu);
            writer.Write(' ');
            writer.Write(OS);
        }

    }
}
