using ChistesPrueba.Models;
using ChistesPrueba.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChistesPrueba.ViewModels
{
    public class ChistesViewModel : BaseViewModel
    {
        private readonly ChisteService _chisteService;
        private ChisteDatabase _database;

        public ObservableCollection<Chiste> Chistes { get; }
        public Command ObtenerChisteCommand { get; }
        public Command NavigateToPersonajeCommand { get; }


        // Constructor sin parámetros requerido por XAML
        public ChistesViewModel()
        {
            _chisteService = new ChisteService();
            Chistes = new ObservableCollection<Chiste>();
            ObtenerChisteCommand = new Command(async () => await ObtenerChisteAsync());
            NavigateToPersonajeCommand = new Command(async () => await Shell.Current.GoToAsync("personaje"));
        }

        // Constructor con base de datos
        public ChistesViewModel(ChisteDatabase database) : this()
        {
            _database = database;
            Task.Run(async () => await CargarChistesAsync());
        }

        public void SetDatabase(ChisteDatabase database)
        {
            _database = database;
        }

        async Task ObtenerChisteAsync()
        {
            var texto = await _chisteService.ObtenerChisteAsync();
            var random = new Random();
            var codigo = $"SL{random.Next(1000, 2000)}";
            var chiste = new Chiste { Codigo = codigo, Texto = texto };

            await _database.SaveChisteAsync(chiste);
            Chistes.Add(chiste);
        }

        async Task CargarChistesAsync()
        {
            var chistes = await _database.GetChistesAsync();
            foreach (var chiste in chistes)
            {
                Chistes.Add(chiste);
            }
        }
    }
}
