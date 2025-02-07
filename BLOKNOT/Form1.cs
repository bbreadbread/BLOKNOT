using System.Windows.Forms;

namespace BLOKNOT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Блокнот";
            this.Width = 800;
            this.Height = 600;

            // Создаем меню
            MenuStrip menuStrip = new MenuStrip();
            this.MainMenuStrip = menuStrip;
            menuStrip.Dock = DockStyle.Top;  // Привязываем меню к верхней части
            this.Controls.Add(menuStrip);

            // Меню "Файл"
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            menuStrip.Items.Add(fileMenu);
            fileMenu.DropDownItems.Add("Создать", null, NewFile);
            fileMenu.DropDownItems.Add("Открыть", null, OpenFile);
            fileMenu.DropDownItems.Add("Сохранить", null, SaveFile);
            fileMenu.DropDownItems.Add("Выход", null, ExitApp);

            // Меню "Правка"
            ToolStripMenuItem editMenu = new ToolStripMenuItem("Правка");
            menuStrip.Items.Add(editMenu);
            editMenu.DropDownItems.Add("Отменить", null, Undo);
            editMenu.DropDownItems.Add("Вырезать", null, Cut);
            editMenu.DropDownItems.Add("Копировать", null, Copy);
            editMenu.DropDownItems.Add("Вставить", null, Paste);
            editMenu.DropDownItems.Add("Удалить", null, DeleteText);
            editMenu.DropDownItems.Add("Найти", null, FindText);
            editMenu.DropDownItems.Add("Заменить", null, ReplaceText);
            editMenu.DropDownItems.Add("Выделить всё", null, SelectAll);
            editMenu.DropDownItems.Add("Вставить картинку", null, InsertPicture);

            statusLabel = new Label
            {
                Dock = DockStyle.Bottom, // Закрепляем внизу формы
                Text = "Строки: 0 | Символы: 0", // Начальный текст
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 30, // Высота Label
                BackColor = Color.LightGray // Цвет фона
            };

            // Добавляем Label на форму
            this.Controls.Add(statusLabel);

            // Меню "Формат"
            ToolStripMenuItem formatMenu = new ToolStripMenuItem("Формат");
            menuStrip.Items.Add(formatMenu);
            formatMenu.DropDownItems.Add("Шрифт", null, ChangeFont);
            formatMenu.DropDownItems.Add("Время и дата", null, InsertDateTime);

            // Добавляем RichTextBox
            richTextBox = new RichTextBox();
            richTextBox.Location = new Point(0, menuStrip.Height + 10); // Устанавливаем отступ 10 пикселей от меню
            richTextBox.Size = new Size(this.ClientSize.Width, this.ClientSize.Height - menuStrip.Height - 10); // Установка высоты
            this.Controls.Add(richTextBox);
        }
        private RichTextBox richTextBox = new RichTextBox();


        // Методы для меню "Файл"
        private void NewFile(object sender, EventArgs e)
        {
            if (richTextBox.Text.Length > 0)
            {
                var result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Внимание", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFile(sender, e); // вызов метода для сохранения
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // отменить действие
                }
            }

            richTextBox.Clear();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string content = File.ReadAllText(openFileDialog.FileName);
                richTextBox.Text = content; // Если файл пустой, это будет пустая строка
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBox.Text);
            }
        }

        private void ExitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Методы для меню "Правка"
        private void Undo(object sender, EventArgs e)
        {
            if (richTextBox.CanUndo)
                richTextBox.Undo();
        }

        private void Cut(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void Copy(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void Paste(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void DeleteText(object sender, EventArgs e)
        {
            richTextBox.SelectedText = "";
        }

        private void FindText(object sender, EventArgs e)
        {
            string searchText = Prompt.ShowDialog("Введите текст для поиска:", "Найти");
            int index = richTextBox.Text.IndexOf(searchText);
            if (index >= 0)
            {
                richTextBox.Select(index, searchText.Length);
                richTextBox.Focus();
            }
            else
            {
                MessageBox.Show("Текст не найден.");
            }
        }

        private void ReplaceText(object sender, EventArgs e)
        {
            using (ReplaceForm replaceForm = new ReplaceForm())
            {
                if (replaceForm.ShowDialog() == DialogResult.OK)
                {
                    string searchText = replaceForm.SearchText;
                    string replaceText = replaceForm.ReplaceText;

                    if (richTextBox.Text.Contains(searchText))
                    {
                        richTextBox.Text = richTextBox.Text.Replace(searchText, replaceText);
                    }
                    else
                    {
                        MessageBox.Show("Текст для поиска не найден.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void SelectAll(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }

        // Методы для меню "Формат"
        private void ChangeFont(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.Font = fontDialog.Font;
            }
        }

        private void InsertDateTime(object sender, EventArgs e)
        {
            richTextBox.AppendText(DateTime.Now.ToString());
        }

        // Вспомогательный класс для ввода текста
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    Text = caption
                };
                Label label = new Label() { Left = 10, Top = 10, Text = text, Width = 360 };
                TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 360 };
                Button confirmation = new Button() { Text = "OK", Left = 280, Width = 90, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(label);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.ShowDialog();
                return textBox.Text;
            }
        }

        public void InsertPicture(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Можно добавить другие форматы

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем изображение
                    string filePath = openFileDialog.FileName;

                    // Вставляем как смайлик в RichTextBox
                    InsertImageAsEmoji(filePath);
                }
            }
        }
        private void InsertImageAsEmoji(string imagePath)
        {
            // Загружаем изображение
            Image image = Image.FromFile(imagePath);

            // Сохраняем изображение в формате Bitmap, чтобы избежать проблем с памятью
            using (Bitmap bitmap = new Bitmap(image))
            {
                // Устанавливаем размер изображения на желаемый (например, 20x20)
                Image resizedImage = new Bitmap(bitmap, new Size(20, 20));

                // Создаем новый объëкт для рисования
                Clipboard.SetImage(resizedImage);
                richTextBox.Paste(); // Вставляет изображение из буфера обмена
            }
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            string text = richTextBox.Text;

            int lineCount = richTextBox.Lines.Length;

            int charCount = text.Length;

            statusLabel.Text = $"Строки: {lineCount} | Символы: {charCount}";
        }
    }
}

