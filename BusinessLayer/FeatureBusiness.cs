using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shared;

namespace BusinessLayer {
	public static class FeatureBusiness {
		public static List<Feature> GetAll() => Repositories.Instance.FeatureRepository.GetAll();

		public static Feature Get(int id) => GetAll().FirstOrDefault(feature => feature.ID == id);

		public static int Insert(Feature feature) => Repositories.Instance.FeatureRepository.InsertGetID(feature);
	}
}
