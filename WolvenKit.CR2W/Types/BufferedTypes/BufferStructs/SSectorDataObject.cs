﻿using System.Collections.Generic;
using System.IO;
using WolvenKit.CR2W.Editors;
using System.Diagnostics;
using System;
using System.Linq;
using System.Runtime.Serialization;
using WolvenKit.CR2W.Reflection;

namespace WolvenKit.CR2W.Types
{
    [REDMeta(EREDMetaInfo.REDStruct)]
    public class CSectorDataObject : CVariable
    {
        [RED] public CUInt8 type { get; set; }
        [RED] public CUInt8 flags { get; set; }
        [RED] public CUInt16 radius { get; set; }
        [RED] public CUInt64 offset { get; set; }
        [RED] public CFloat positionX { get; set; }
        [RED] public CFloat positionY { get; set; }
        [RED] public CFloat positionZ { get; set; }

        public CSectorDataObject(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {

        }

        public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new CSectorDataObject(cr2w, parent, name);
        }

        public override void Read(BinaryReader file, uint size) => base.Read(file, size);

        public override void Write(BinaryWriter file) => base.Write(file);


    }
}