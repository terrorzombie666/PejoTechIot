﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PejoTechIot.Autopilot.Helper
{
    /// <summary>  
    /// The distance type to return the results in.  
    /// </summary>  
    public enum DistanceType
    {
        Miles,
        Kilometers
    };

    /// <summary>  
    /// Specifies a Latitude / Longitude point.  
    /// </summary>  
    public struct Position
    {
        public double Latitude;
        public double Longitude;
    }

    public static class Haversine
    {
        /// <summary>  
        /// Returns the distance in miles or kilometers of any two  
        /// latitude / longitude points.  
        /// </summary>  
        public static double Distance(Position pos1, Position pos2, DistanceType type)
        {
            double R = (type == DistanceType.Miles) ? 3960 : 6371;
            double dLat = Haversine.ToRadian(pos2.Latitude - pos1.Latitude);
            double dLon = Haversine.ToRadian(pos2.Longitude - pos1.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(Haversine.ToRadian(pos1.Latitude)) * Math.Cos(Haversine.ToRadian(pos2.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;
            return d;
        }

        /// <summary>  
        /// Convert to Radians.  
        /// </summary>  
        private static double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
