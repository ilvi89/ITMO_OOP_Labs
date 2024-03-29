﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using BackupsExtra.Entity;
using BackupsExtra.Repo;

namespace BackupsExtra
{
    [Serializable]
    public class RestoreRepo : IRestorePointRepo
    {
        public RestoreRepo()
        {
            Points = new List<RestorePoint>();
        }

        public List<RestorePoint> Points { get; }

        public RestorePoint Save(RestorePoint restorePoint)
        {
            if (Points.Contains(restorePoint))
                Points[Points.FindIndex(point => point.Id == restorePoint.Id)] = restorePoint;
            Points.Add(restorePoint);
            return restorePoint;
        }

        public RestorePoint DeleteLatter(RestorePoint restorePoint)
        {
            if (restorePoint == null) return null;
            return DeleteLatter(restorePoint.CreatedAt);
        }

        public RestorePoint DeleteLatter(DateTime dateTime)
        {
            Points.Sort((f, s) => f.CreatedAt.CompareTo(s.CreatedAt));
            int rs = Points.FindIndex(point => point.CreatedAt == dateTime);
            Points.RemoveRange(0, rs);
            return Points[0];
        }

        public RestorePoint GetByOrder(int count)
        {
            Points.Sort((f, s) => f.CreatedAt.CompareTo(s.CreatedAt));
            if (Points.ElementAt(count) != null)
                return Points[count];
            return null;
        }

        public RestorePoint GetPrev(RestorePoint restorePoint)
        {
            throw new NotImplementedException();
        }
    }
}