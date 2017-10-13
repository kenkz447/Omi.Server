using Omi.Modules.FileAndMedia.Entities;
using Omi.Modules.FileAndMedia.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Omi.Modules.FileAndMedia.ViewModel
{
    public class FileEntityInfo
    {
        public FileEntityInfo()
        {

        }

        public FileEntityInfo(FileEntity fileEntity)
        {
            FileId = fileEntity.Id;

            var fileMeta = fileEntity.GetMeta();

            if (fileMeta.ThumbnailFileName != null)
                srcThumb = $"{Path.GetDirectoryName(fileEntity.Src)}/{fileMeta.ThumbnailFileName}".Replace('\\','/');

            Src = fileEntity.Src;
        }

        public long FileId { get; set; }
        public string Src { get; set; }
        public string srcThumb {get;set;}
    }
}