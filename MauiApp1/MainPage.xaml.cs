using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiApp1 // Убедитесь, что пространство имен совпадает
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;

        public MainPage(Database database)
        {
            InitializeComponent(); // Это должно работать, если файл XAML правильно настроен
            _database = database;
            LoadNotes();
        }

        private async void LoadNotes()
        {
            var notes = await _database.GetNotesAsync();
            NotesListView.ItemsSource = notes; // Это должно работать, если NotesListView определен в XAML
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            var note = new Note { Text = NoteEntry.Text }; // Это должно работать, если NoteEntry определен в XAML
            await _database.SaveNoteAsync(note);
            NoteEntry.Text = string.Empty;
            LoadNotes();
        }
    }
}