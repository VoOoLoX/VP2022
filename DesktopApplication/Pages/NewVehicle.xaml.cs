using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Linq;
using BusinessLayer;
using Shared;
using Image = Shared.Image;

namespace DesktopApplication.Pages
{
    public partial class NewVehicle : Page
    {
        public NewVehicle()
        {
            InitializeComponent();
			DataContext = this;

            NewVehicleButton.OnClick += AddNewVehicle;
        }

		private void AddNewVehicle() {
            var manufacturer = new Manufacturer() {
                Name = VehicleManufacturer.Text
            };

            var model = new VehicleModel() {
                Name = VehicleModel.Text
            };

            var type = new VehicleType() {
                Name = VehicleType.Text
            };

            var feature = new Feature() {
                CruiseControl = VehicleCruiseControl.IsChecked,
                ParkingSensors = VehicleParkingSensor.IsChecked,
                ElectricWindows = VehicleElectricWindows.IsChecked,
                Sunroof = VehicleSunroof.IsChecked,
                XenonHeadlights = VehicleXenonHeadlights.IsChecked,
                Multimedia = VehicleMultimedia.IsChecked,
                PowerAssistedSteering = VehiclePowerSteering.IsChecked,
                AirConditioning = VehicleAirConditioning.IsChecked,
                Navigation = VehicleNavigation.IsChecked
            };

            var security = new Security() {
                Airbag = VehicleAirbag.IsChecked,
                ESP = VehicleESP.IsChecked,
                ASR = VehicleASR.IsChecked,
                ABS = VehicleABS.IsChecked,
                ChildLock = VehicleChildlock.IsChecked,
                Immobiliser = VehicleImmobiliser.IsChecked,
                CentralLocking = VehicleCentralLocking.IsChecked
            };

            var image = new Image() {
                Link = VehicleImages.Text.Split('/').Last()
            };

            var manufacturer_id = ManufacturerBusiness.Insert(manufacturer);

            var model_id = VehicleModelBusiness.Insert(model);

            var type_id = VehicleTypeBusiness.Insert(type);

            var feature_id = FeatureBusiness.Insert(feature);

            var security_id = SecurityBusiness.Insert(security);

            var image_id = ImageBusiness.Insert(image);

            if (feature_id > 0 && security_id > 0 && image_id > 0 && manufacturer_id > 0 && model_id > 0 && type_id > 0) {
                var vehicle = new Vehicle() {
                    Price = decimal.Parse(VehiclePrice.Text ?? "0"),
                    Mileage = decimal.Parse(VehicleMileage.Text ?? "0"),
                    Color = VehicleColor.Text,
                    Fuel = VehicleFuel.Text,
                    Description = VehicleDescription.Text,
                    Year = int.Parse(VehicleYear.Text ?? "0"),
                    CubicCapacity = int.Parse(VehicleCubicCapacity.Text ?? "0"),
                    HorsePower = int.Parse(VehicleHorsePower.Text ?? "0"),
					ManufacturerID = manufacturer_id,
					ModelID = model_id,
					TypeID = type_id,
					FeaturesID = feature_id,
					SecurityID = security_id,
					ImagesID = image_id,
                };

                if (VehicleBusiness.Insert(vehicle))
                    MessageBox.Show("Vozilo uspešno dodato", "Operacija uspešna", MessageBoxButton.OK, MessageBoxImage.None);
                else
                    MessageBox.Show("Došlo je do greške", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
            } else {
                MessageBox.Show("Došlo je do greške", "Operacija neuspešna", MessageBoxButton.OK, MessageBoxImage.Error);
			}
        }

	}
}
