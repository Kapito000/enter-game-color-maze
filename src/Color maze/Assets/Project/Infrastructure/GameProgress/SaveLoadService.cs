using System;
using System.IO;
using UniRx;
using UnityEngine;

namespace Infrastructure.GameProgress
{
	public class SaveLoadService : ISaveLoadService, IDisposable
	{
		const string _saveFileName = "game progress.json";

		Subject<GameProgress> _saveProgress = new();
		Subject<GameProgress> _loadProgress = new();

		public IObservable<GameProgress> SavingProgress => _saveProgress;
		public IObservable<GameProgress> LoadingProgress => _loadProgress;

		public void SaveProgress()
		{
			var gameProgress = new GameProgress();

			_saveProgress.OnNext(gameProgress);

			string json = JsonUtility.ToJson(gameProgress, true);

			var saveFilePath = SaveFilePath();
			WriteToFile(saveFilePath, json);
		}

		public void LoadProgress()
		{
			var saveFilePath = SaveFilePath();
			if (!File.Exists(saveFilePath))
				return;

			string json = ReadFromFile(saveFilePath);

			var progress = JsonUtility.FromJson<GameProgress>(json);
			_loadProgress.OnNext(progress);
		}

		void WriteToFile(string filePath, string data)
		{
			using StreamWriter writer = new StreamWriter(filePath);
			writer.Write(data);
		}

		string ReadFromFile(string filePath)
		{
			using StreamReader reader = new StreamReader(filePath);
			return reader.ReadToEnd();
		}

		string SaveFilePath() =>
			Path.Combine(Application.persistentDataPath, _saveFileName);

		public void Dispose()
		{
			_saveProgress.OnCompleted();
			_saveProgress?.Dispose();
			_loadProgress.OnCompleted();
			_loadProgress?.Dispose();
		}
	}
}