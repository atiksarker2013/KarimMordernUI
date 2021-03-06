﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Shared;

namespace Data.EM
{
   public class EM_KarimBook
    {
        public static KarimBook ConverToModel(tbl_KarimBook entity)
        {
            KarimBook model = new KarimBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;
            model.Edition = entity.Edition.TrimWithNull();
            model.BookBinding = entity.BookBinding.TrimWithNull();

            return model;
        }

       

        public static tbl_KarimBook ConvertToEntity(KarimBook model)
        {
            tbl_KarimBook entity = new tbl_KarimBook();

            entity.Id = model.Id;
            entity.Title = model.Title;
            entity.Writer = model.Writer;
            entity.Publisher = model.Publisher;
            entity.Qty = model.Qty;
            entity.Price = model.Price;


            entity.PublisherPrice = model.PublisherPrice;
            entity.PublisherUnit = model.PublisherUnit;
            entity.PublishYear = model.PublishYear;
            entity.BookType = model.BookType;

            entity.Barcode = model.Barcode;
            entity.OutOfStock = model.OutOfStock;
            entity.InStock = model.InStock;
            entity.EntryDate = model.EntryDate;


            entity.Edition = model.Edition;
            entity.BookBinding = model.BookBinding;


            return entity;
        }

        internal static KarimBook ConvertToModel(USP_GetKarimBookList_Result entity)
        {
            KarimBook model = new KarimBook();

            model.Id = entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;
            model.Edition = entity.Edition.TrimWithNull();
            model.BookBinding = entity.BookBinding.TrimWithNull();

            return model;
        }

        internal static KarimBook ConvertToModel(USP_GetKarimBookWithBdPriceListALLSubjectWise_Result entity)
        {
            KarimBook model = new KarimBook();

            model.Id = (int)entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;
            model.Edition = entity.Edition.TrimWithNull();
            model.BookBinding = entity.BookBinding.TrimWithNull();

            return model;
        }

        internal static KarimBook ConvertToModel(USP_GetKarimBookWithBdPriceList_Result entity)
        {
            KarimBook model = new KarimBook();

            model.Id = (int)entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;
            model.Edition = entity.Edition.TrimWithNull();
            model.BookBinding = entity.BookBinding.TrimWithNull();

            return model;
        }

        internal static KarimBook ConvertToModel(USP_GetKarimBookWithBdPriceListALL_Result entity)
        {
            KarimBook model = new KarimBook();

            model.Id = (int)entity.Id;
            model.Title = entity.Title.TrimWithNull();
            model.Writer = entity.Writer.TrimWithNull();
            model.Publisher = entity.Publisher.TrimWithNull();
            model.Barcode = entity.Barcode.TrimWithNull();
            model.Qty = entity.Qty ?? 0;
            model.Price = entity.Price ?? 0;
            model.PublisherPrice = entity.PublisherPrice ?? 0;
            model.PublisherUnit = entity.PublisherUnit.TrimWithNull();
            model.PublishYear = entity.PublishYear;
            model.BookType = entity.BookType.TrimWithNull();
            model.OutOfStock = entity.OutOfStock ?? 0;
            model.InStock = entity.InStock ?? 0;
            model.EntryDate = entity.EntryDate;
            model.Edition = entity.Edition.TrimWithNull();
            model.BookBinding = entity.BookBinding.TrimWithNull();

            return model;
        }
    }
}
