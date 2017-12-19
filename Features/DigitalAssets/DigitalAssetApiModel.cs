using System;
using ECommerceApp.Model;

namespace ECommerceApp.Features.DigitalAssets
{
    public class DigitalAssetApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public long? Size { get; set; }
        public string ContentType { get; set; }
        public string RelativePath { get { return $"api/digitalasset/serve?uniqueid={UniqueId}"; } }
        public byte[] Bytes { get; set; } = new byte[0];
        public Guid? UniqueId { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public static TModel FromDigitalAsset<TModel>(DigitalAsset digitalAsset) where
            TModel : DigitalAssetApiModel, new()
        {
            var model = new TModel();
            model.Id = digitalAsset.Id;
            model.Bytes = digitalAsset.Bytes;
            model.Folder = digitalAsset.Folder;
            model.Name = digitalAsset.Name;
            model.FileName = digitalAsset.FileName;
            model.Description = digitalAsset.Description;
            model.CreatedOn = digitalAsset.CreatedOn;
            model.LastModifiedOn = digitalAsset.LastModifiedOn;
            model.Size = digitalAsset.Size;
            model.ContentType = digitalAsset.ContentType;
            model.UniqueId = digitalAsset.UniqueId;
            model.CreatedBy = digitalAsset.CreatedBy;
            return model;
        }

        public static DigitalAssetApiModel FromDigitalAsset(DigitalAsset digitalAsset)
            => FromDigitalAsset<DigitalAssetApiModel>(digitalAsset);

    }
}