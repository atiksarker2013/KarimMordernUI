﻿using Models;
namespace Data
{
    public static class EM_SalesDetails
    {

        public static SalesDetails ConverToModel(tbl_SalesDetails entity)
        {
            SalesDetails model = new SalesDetails();

            model.Id = entity.Id;
            model.SalesId = entity.SalesId ?? 0;
            model.BookId = entity.BookId ?? 0;
            model.OrderQty = entity.OrderQty ?? 0;
            model.ReturnQty = entity.ReturnQty ?? 0;
            model.Price = entity.Price ?? 0;

            return model;
        }

        public static tbl_SalesDetails ConvertToEntity(SalesDetails model)
        {
            tbl_SalesDetails entity = new tbl_SalesDetails();

            entity.Id = model.Id;
            entity.SalesId = model.SalesId;
            entity.BookId = model.BookId;
            entity.OrderQty = model.OrderQty;
            entity.ReturnQty = model.ReturnQty;
            entity.Price = model.Price;

            return entity;
        }
    }
}