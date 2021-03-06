﻿using System;
using Models;
using Shared;
namespace Data
{
    public static class EM_DarusSalamBook
    {

        public static DarusSalamBook ConverToModel(tbl_DarusSalamBook entity)
        {
            DarusSalamBook model = new DarusSalamBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;

            return model;
        }

        internal static DarusSalamBook ConvertToModel(USP_GetBookList_Result entity)
        {
            DarusSalamBook model = new DarusSalamBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;

            return model;
        }

        public static tbl_DarusSalamBook ConvertToEntity(DarusSalamBook model)
        {
            tbl_DarusSalamBook entity = new tbl_DarusSalamBook();

            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.Writer = model.Writer;
            entity.Publisher = model.Publisher;
            entity.Qty = model.Qty;
            entity.Price = model.Price;
            entity.Barcode = model.Barcode;
            entity.OutOfStock = model.OutOfStock;
            entity.InStock = model.InStock;
            entity.EntryDate = model.EntryDate;
            

            return entity;
        }
    }
}