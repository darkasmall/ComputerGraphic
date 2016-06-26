namespace lab7
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pointsBox = new System.Windows.Forms.ListBox();
            this.deletePointButton = new System.Windows.Forms.Button();
            this.addEdgeButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEdgeSource = new System.Windows.Forms.ComboBox();
            this.comboBoxEdgeEnd = new System.Windows.Forms.ComboBox();
            this.edgesBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteEdgeButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxScX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxScY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scaleButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxPhi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rotateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxShX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxShY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.shiftButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.rotateAroundPointButton = new System.Windows.Forms.Button();
            this.rotateEdgeButton = new System.Windows.Forms.Button();
            this.edgeIntersectButton = new System.Windows.Forms.Button();
            this.comboBoxEdgeIntsct2 = new System.Windows.Forms.ComboBox();
            this.comboBoxEdgeIntsct1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxSaveToFile = new System.Windows.Forms.TextBox();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.loadFroamFileButton = new System.Windows.Forms.Button();
            this.delaunayButton = new System.Windows.Forms.Button();
            this.isPointInsideTextBox = new System.Windows.Forms.TextBox();
            this.isPointInsideButton = new System.Windows.Forms.Button();
            this.createPolygonButton = new System.Windows.Forms.Button();
            this.refreshPictureButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(492, 555);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // pointsBox
            // 
            this.pointsBox.FormattingEnabled = true;
            this.pointsBox.Location = new System.Drawing.Point(13, 10);
            this.pointsBox.Name = "pointsBox";
            this.pointsBox.Size = new System.Drawing.Size(89, 134);
            this.pointsBox.TabIndex = 1;
            this.pointsBox.SelectedIndexChanged += new System.EventHandler(this.pointsBox_SelectedIndexChanged);
            // 
            // deletePointButton
            // 
            this.deletePointButton.Location = new System.Drawing.Point(13, 150);
            this.deletePointButton.Name = "deletePointButton";
            this.deletePointButton.Size = new System.Drawing.Size(89, 37);
            this.deletePointButton.TabIndex = 2;
            this.deletePointButton.Text = "Удалить точку";
            this.deletePointButton.UseVisualStyleBackColor = true;
            this.deletePointButton.Click += new System.EventHandler(this.deletePointButton_Click);
            // 
            // addEdgeButton
            // 
            this.addEdgeButton.Location = new System.Drawing.Point(13, 61);
            this.addEdgeButton.Name = "addEdgeButton";
            this.addEdgeButton.Size = new System.Drawing.Size(149, 23);
            this.addEdgeButton.TabIndex = 10;
            this.addEdgeButton.Text = "Добавить ребро";
            this.addEdgeButton.UseVisualStyleBackColor = true;
            this.addEdgeButton.Click += new System.EventHandler(this.addEdgeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Из:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "В:";
            // 
            // comboBoxEdgeSource
            // 
            this.comboBoxEdgeSource.FormattingEnabled = true;
            this.comboBoxEdgeSource.Location = new System.Drawing.Point(40, 7);
            this.comboBoxEdgeSource.Name = "comboBoxEdgeSource";
            this.comboBoxEdgeSource.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEdgeSource.TabIndex = 14;
            this.comboBoxEdgeSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdgeSource_SelectedIndexChanged);
            // 
            // comboBoxEdgeEnd
            // 
            this.comboBoxEdgeEnd.FormattingEnabled = true;
            this.comboBoxEdgeEnd.Location = new System.Drawing.Point(40, 34);
            this.comboBoxEdgeEnd.Name = "comboBoxEdgeEnd";
            this.comboBoxEdgeEnd.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEdgeEnd.TabIndex = 15;
            this.comboBoxEdgeEnd.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdgeSource_SelectedIndexChanged);
            // 
            // edgesBox
            // 
            this.edgesBox.FormattingEnabled = true;
            this.edgesBox.Location = new System.Drawing.Point(12, 119);
            this.edgesBox.Name = "edgesBox";
            this.edgesBox.Size = new System.Drawing.Size(148, 69);
            this.edgesBox.TabIndex = 20;
            this.edgesBox.SelectedIndexChanged += new System.EventHandler(this.edgesBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 64);
            this.button1.TabIndex = 22;
            this.button1.Text = "Узнать положение выбранной точки относительно выбранного ребра";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(137, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 64);
            this.textBox1.TabIndex = 23;
            // 
            // deleteEdgeButton
            // 
            this.deleteEdgeButton.Location = new System.Drawing.Point(13, 90);
            this.deleteEdgeButton.Name = "deleteEdgeButton";
            this.deleteEdgeButton.Size = new System.Drawing.Size(147, 23);
            this.deleteEdgeButton.TabIndex = 21;
            this.deleteEdgeButton.Text = "Удалить ребро";
            this.deleteEdgeButton.UseVisualStyleBackColor = true;
            this.deleteEdgeButton.Click += new System.EventHandler(this.deleteEdgeButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleName = "";
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(498, 231);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 281);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.scaleButton);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.rotateButton);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.shiftButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Афинные преобразования";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBoxScX);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.textBoxScY);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(104, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(89, 52);
            this.panel3.TabIndex = 25;
            // 
            // textBoxScX
            // 
            this.textBoxScX.Location = new System.Drawing.Point(25, 3);
            this.textBoxScX.Name = "textBoxScX";
            this.textBoxScX.Size = new System.Drawing.Size(57, 20);
            this.textBoxScX.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "α";
            // 
            // textBoxScY
            // 
            this.textBoxScY.Location = new System.Drawing.Point(25, 26);
            this.textBoxScY.Name = "textBoxScY";
            this.textBoxScY.Size = new System.Drawing.Size(57, 20);
            this.textBoxScY.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "β";
            // 
            // scaleButton
            // 
            this.scaleButton.Location = new System.Drawing.Point(6, 105);
            this.scaleButton.Name = "scaleButton";
            this.scaleButton.Size = new System.Drawing.Size(92, 52);
            this.scaleButton.TabIndex = 24;
            this.scaleButton.Text = "Масштаб";
            this.scaleButton.UseVisualStyleBackColor = true;
            this.scaleButton.Click += new System.EventHandler(this.scaleButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxPhi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(104, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 35);
            this.panel2.TabIndex = 23;
            // 
            // textBoxPhi
            // 
            this.textBoxPhi.Location = new System.Drawing.Point(25, 3);
            this.textBoxPhi.Name = "textBoxPhi";
            this.textBoxPhi.Size = new System.Drawing.Size(57, 20);
            this.textBoxPhi.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ρ";
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(6, 64);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(92, 35);
            this.rotateButton.TabIndex = 22;
            this.rotateButton.Text = "Поворот";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxShX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxShY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(104, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(89, 52);
            this.panel1.TabIndex = 21;
            // 
            // textBoxShX
            // 
            this.textBoxShX.Location = new System.Drawing.Point(25, 3);
            this.textBoxShX.Name = "textBoxShX";
            this.textBoxShX.Size = new System.Drawing.Size(57, 20);
            this.textBoxShX.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "X";
            // 
            // textBoxShY
            // 
            this.textBoxShY.Location = new System.Drawing.Point(25, 26);
            this.textBoxShY.Name = "textBoxShY";
            this.textBoxShY.Size = new System.Drawing.Size(57, 20);
            this.textBoxShY.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // shiftButton
            // 
            this.shiftButton.Location = new System.Drawing.Point(6, 6);
            this.shiftButton.Name = "shiftButton";
            this.shiftButton.Size = new System.Drawing.Size(92, 52);
            this.shiftButton.TabIndex = 20;
            this.shiftButton.Text = "Сдвиг";
            this.shiftButton.UseVisualStyleBackColor = true;
            this.shiftButton.Click += new System.EventHandler(this.shiftButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.rotateAroundPointButton);
            this.tabPage2.Controls.Add(this.rotateEdgeButton);
            this.tabPage2.Controls.Add(this.edgeIntersectButton);
            this.tabPage2.Controls.Add(this.comboBoxEdgeIntsct2);
            this.tabPage2.Controls.Add(this.comboBoxEdgeIntsct1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Базовые алгоритмы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Угол поворота:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 204);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 29;
            // 
            // rotateAroundPointButton
            // 
            this.rotateAroundPointButton.Location = new System.Drawing.Point(6, 182);
            this.rotateAroundPointButton.Name = "rotateAroundPointButton";
            this.rotateAroundPointButton.Size = new System.Drawing.Size(124, 63);
            this.rotateAroundPointButton.TabIndex = 28;
            this.rotateAroundPointButton.Text = "Повернуть выбранное ребро вокруг выбранной точки";
            this.rotateAroundPointButton.UseVisualStyleBackColor = true;
            // 
            // rotateEdgeButton
            // 
            this.rotateEdgeButton.Location = new System.Drawing.Point(6, 132);
            this.rotateEdgeButton.Name = "rotateEdgeButton";
            this.rotateEdgeButton.Size = new System.Drawing.Size(125, 45);
            this.rotateEdgeButton.TabIndex = 27;
            this.rotateEdgeButton.Text = "Повернуть выбранное ребро";
            this.rotateEdgeButton.UseVisualStyleBackColor = true;
            this.rotateEdgeButton.Click += new System.EventHandler(this.rotateEdgeButton_Click);
            // 
            // edgeIntersectButton
            // 
            this.edgeIntersectButton.Location = new System.Drawing.Point(6, 76);
            this.edgeIntersectButton.Name = "edgeIntersectButton";
            this.edgeIntersectButton.Size = new System.Drawing.Size(125, 50);
            this.edgeIntersectButton.TabIndex = 26;
            this.edgeIntersectButton.Text = "Пересечение ребер";
            this.edgeIntersectButton.UseVisualStyleBackColor = true;
            this.edgeIntersectButton.Click += new System.EventHandler(this.edgeIntersectButton_Click);
            // 
            // comboBoxEdgeIntsct2
            // 
            this.comboBoxEdgeIntsct2.FormattingEnabled = true;
            this.comboBoxEdgeIntsct2.Location = new System.Drawing.Point(137, 105);
            this.comboBoxEdgeIntsct2.Name = "comboBoxEdgeIntsct2";
            this.comboBoxEdgeIntsct2.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEdgeIntsct2.TabIndex = 25;
            this.comboBoxEdgeIntsct2.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdgeIntsct1_SelectedIndexChanged);
            // 
            // comboBoxEdgeIntsct1
            // 
            this.comboBoxEdgeIntsct1.FormattingEnabled = true;
            this.comboBoxEdgeIntsct1.Location = new System.Drawing.Point(137, 78);
            this.comboBoxEdgeIntsct1.Name = "comboBoxEdgeIntsct1";
            this.comboBoxEdgeIntsct1.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEdgeIntsct1.TabIndex = 24;
            this.comboBoxEdgeIntsct1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdgeIntsct1_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxSaveToFile);
            this.tabPage3.Controls.Add(this.saveToFileButton);
            this.tabPage3.Controls.Add(this.textBoxFilePath);
            this.tabPage3.Controls.Add(this.loadFroamFileButton);
            this.tabPage3.Controls.Add(this.delaunayButton);
            this.tabPage3.Controls.Add(this.isPointInsideTextBox);
            this.tabPage3.Controls.Add(this.isPointInsideButton);
            this.tabPage3.Controls.Add(this.createPolygonButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(292, 255);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Полигон";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxSaveToFile
            // 
            this.textBoxSaveToFile.Location = new System.Drawing.Point(156, 211);
            this.textBoxSaveToFile.Name = "textBoxSaveToFile";
            this.textBoxSaveToFile.Size = new System.Drawing.Size(100, 20);
            this.textBoxSaveToFile.TabIndex = 31;
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Location = new System.Drawing.Point(10, 209);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(140, 23);
            this.saveToFileButton.TabIndex = 30;
            this.saveToFileButton.Text = "Сохранить в файл";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.saveToFileButton_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(156, 182);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilePath.TabIndex = 29;
            // 
            // loadFroamFileButton
            // 
            this.loadFroamFileButton.Location = new System.Drawing.Point(10, 180);
            this.loadFroamFileButton.Name = "loadFroamFileButton";
            this.loadFroamFileButton.Size = new System.Drawing.Size(140, 23);
            this.loadFroamFileButton.TabIndex = 28;
            this.loadFroamFileButton.Text = "Загрузить из файла";
            this.loadFroamFileButton.UseVisualStyleBackColor = true;
            this.loadFroamFileButton.Click += new System.EventHandler(this.loadFroamFileButton_Click);
            // 
            // delaunayButton
            // 
            this.delaunayButton.Location = new System.Drawing.Point(6, 121);
            this.delaunayButton.Name = "delaunayButton";
            this.delaunayButton.Size = new System.Drawing.Size(98, 53);
            this.delaunayButton.TabIndex = 3;
            this.delaunayButton.Text = "Триангуляция Делоне";
            this.delaunayButton.UseVisualStyleBackColor = true;
            this.delaunayButton.Click += new System.EventHandler(this.delaunayButton_Click);
            // 
            // isPointInsideTextBox
            // 
            this.isPointInsideTextBox.Location = new System.Drawing.Point(110, 81);
            this.isPointInsideTextBox.Name = "isPointInsideTextBox";
            this.isPointInsideTextBox.Size = new System.Drawing.Size(100, 20);
            this.isPointInsideTextBox.TabIndex = 2;
            // 
            // isPointInsideButton
            // 
            this.isPointInsideButton.Location = new System.Drawing.Point(6, 65);
            this.isPointInsideButton.Name = "isPointInsideButton";
            this.isPointInsideButton.Size = new System.Drawing.Size(98, 50);
            this.isPointInsideButton.TabIndex = 1;
            this.isPointInsideButton.Text = "Проверка положения точки";
            this.isPointInsideButton.UseVisualStyleBackColor = true;
            this.isPointInsideButton.Click += new System.EventHandler(this.isPointInsideButton_Click);
            // 
            // createPolygonButton
            // 
            this.createPolygonButton.Location = new System.Drawing.Point(6, 6);
            this.createPolygonButton.Name = "createPolygonButton";
            this.createPolygonButton.Size = new System.Drawing.Size(98, 53);
            this.createPolygonButton.TabIndex = 0;
            this.createPolygonButton.Text = "Создать полигон";
            this.createPolygonButton.UseVisualStyleBackColor = true;
            this.createPolygonButton.Click += new System.EventHandler(this.createPolygonButton_Click);
            // 
            // refreshPictureButton
            // 
            this.refreshPictureButton.Location = new System.Drawing.Point(498, 518);
            this.refreshPictureButton.Name = "refreshPictureButton";
            this.refreshPictureButton.Size = new System.Drawing.Size(131, 37);
            this.refreshPictureButton.TabIndex = 25;
            this.refreshPictureButton.Text = "Обновить картинку";
            this.refreshPictureButton.UseVisualStyleBackColor = true;
            this.refreshPictureButton.Click += new System.EventHandler(this.refreshPictureButton_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pointsBox);
            this.panel4.Controls.Add(this.deletePointButton);
            this.panel4.Location = new System.Drawing.Point(498, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(115, 200);
            this.panel4.TabIndex = 26;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.addEdgeButton);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.comboBoxEdgeSource);
            this.panel5.Controls.Add(this.deleteEdgeButton);
            this.panel5.Controls.Add(this.comboBoxEdgeEnd);
            this.panel5.Controls.Add(this.edgesBox);
            this.panel5.Location = new System.Drawing.Point(624, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(174, 200);
            this.panel5.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 559);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.refreshPictureButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox pointsBox;
        private System.Windows.Forms.Button deletePointButton;
        private System.Windows.Forms.Button addEdgeButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEdgeSource;
        private System.Windows.Forms.ComboBox comboBoxEdgeEnd;
        private System.Windows.Forms.ListBox edgesBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button deleteEdgeButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxScX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxScY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button scaleButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxPhi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxShX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxShY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button shiftButton;
        private System.Windows.Forms.Button edgeIntersectButton;
        private System.Windows.Forms.ComboBox comboBoxEdgeIntsct2;
        private System.Windows.Forms.ComboBox comboBoxEdgeIntsct1;
        private System.Windows.Forms.Button rotateEdgeButton;
        private System.Windows.Forms.Button refreshPictureButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button rotateAroundPointButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button createPolygonButton;
        private System.Windows.Forms.Button isPointInsideButton;
        private System.Windows.Forms.TextBox isPointInsideTextBox;
        private System.Windows.Forms.Button delaunayButton;
        private System.Windows.Forms.Button loadFroamFileButton;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.TextBox textBoxSaveToFile;
    }
}

