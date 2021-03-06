﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiDemo.Models.Interface;
using WebApiDemo.Models;
using System.Data.Entity;

namespace WebApiDemo.Models.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected FabricsEntities db
        {
            get;
            private set;
        }

        public ProductRepository() 
        {
            this.db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
            this.SaveChanges();
        }

        public void Delete(Product product)
        {
            var obj = db.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (obj != null)
            {
                db.Product.Remove(obj);
                db.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("instance");
            }
        }
    
        public Product Get(int id)
        {
            var obj = db.Product.FirstOrDefault(x => x.ProductId == id);
            return obj;
        }

        public IQueryable<Product> GetAll()
        {
            return db.Product;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            var obj = db.Product.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (obj != null)
            {
                obj.Active = product.Active;
                obj.OrderLine = product.OrderLine;
                obj.Price = product.Price;
                obj.ProductName = product.ProductName;
                obj.Stock = product.Stock;
                this.SaveChanges();
            } 
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 處置受控狀態 (受控物件)。
                }

                // TODO: 釋放非受控資源 (非受控物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放非受控資源的程式碼時，才覆寫完成項。
        // ~ProductRepository() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}