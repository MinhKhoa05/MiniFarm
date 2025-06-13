using System;
using System.Windows.Forms;

namespace MiniFarm
{
    public sealed class GameManager
    {
        private static readonly Lazy<GameManager> _instance = new Lazy<GameManager>(() => new GameManager());

        private GameManager()
        {
            // Khởi tạo các thành phần của game ở đây (nếu cần)
        }

        public static GameManager Instance => _instance.Value;

        public void Start()
        {
            // Khởi chạy form chính của game
            Application.Run(new MainForm());
        }
    }
}
