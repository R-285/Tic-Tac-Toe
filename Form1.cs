using System;
using System.Drawing;
using System.Windows.Forms;



namespace XO
{
	public partial class Form1 : Form
	{
		//Глобальные переменные
		public short[,] fields;//Игровое поле ( = 0 - ничего нет, = 1 - нолик,
							   //= 2 - крестик, = 3 - выигравший нолик, = 4 - выигравший крестик
							   //= 5 - последний поставленный нолик, = 6 - последний поставленный крестик)
		float[,] calc_fields;//Рассчитанное значение оценочной функции
		int size_x = 19;//Размер поля по x (19 - по умолчанию)	
		short lastX = -1, lastY = -1; //Для отображения последнего хода компутера
		int attack_factor = 3;   //Коэффициент агрессивности ИИ (3 - по умолчанию)
		short valuation_factor = 4;//Оценочный коэффициент (4 - по умолчанию)
		bool end_game = false;//Наступил конец игры?
		bool player_first_step = true;//Приоритетность хода (true - человек)		

		//Технические моменты (для рисования)
		Bitmap image;
		Graphics g;

		public Form1()
		{
			InitializeComponent();
		}

		//Выведем поле
		public void OnPaint()
		{

			SolidBrush brushBgnd = new SolidBrush(Color.FromArgb(45, 45, 50));//Кисть для заднего фона
			Pen penO = new Pen(Color.FromArgb(67, 166, 58), 2);//Перо для нолика
			Pen penX = new Pen(Color.FromArgb(66, 156, 214), 2);//Перо для крестика
			Pen penWin = new Pen(Color.FromArgb(163, 73, 164), 2);//Перо для выигрышных крестика или нолика
			Pen penLast = new Pen(Color.FromArgb(255, 242, 0), 2);//Перо для вывода последнего крестика или нолика
			Pen penWhite = new Pen(Color.FromArgb(200, 200, 200), 1); //Перо для вывода сетки


			g.FillRectangle(brushBgnd, 0, 0, image.Width, image.Height); //Рисуем задний фон
			for (int y = 0; y < size_x; y++)
			{
				for (int x = 0; x < size_x; x++)
				{
					//Выводим сетку
					g.DrawRectangle(penWhite, x * 15, y * 15, 15, 15);

					g.DrawRectangle(penWhite, x * 15, y * 15, 15, 15);

					//выводим содержимое клеток
					switch (fields[x, y])
					{
						case 0:
							break;
						//Выводим нолик
						case 1:                     //Старый нолик
							if (player_first_step)
							{
								g.DrawLine(penO, x * 15 + 1, y * 15 + 1, x * 15 + 14, y * 15 + 14);
								g.DrawLine(penO, x * 15 + 14, y * 15 + 1, x * 15 + 1, y * 15 + 14);
								break;
							}
							else
							{
								g.DrawEllipse(penO, x * 15 + 1, y * 15 + 1, 13, 13);
							}
							break;
						case 3:                     //Выигрышь
							if (player_first_step)
							{
								g.DrawLine(penWin, x * 15 + 1, y * 15 + 1, x * 15 + 14, y * 15 + 14);
								g.DrawLine(penWin, x * 15 + 14, y * 15 + 1, x * 15 + 1, y * 15 + 14);
								break;
							}
							else
							{
								g.DrawEllipse(penWin, x * 15 + 1, y * 15 + 1, 13, 13);
							}
							break;
						//Выводим крестик
						case 2:                     //Старый нолик
							if ((lastX == x) && (lastY == y)) {
								if (player_first_step)
								{
									g.DrawEllipse(penLast, x * 15 + 1, y * 15 + 1, 13, 13);
								}
								else
								{
									g.DrawLine(penLast, x * 15 + 1, y * 15 + 1, x * 15 + 14, y * 15 + 14);
									g.DrawLine(penLast, x * 15 + 14, y * 15 + 1, x * 15 + 1, y * 15 + 14);
								}
							}
							else
							{
								if (player_first_step)
								{
									g.DrawEllipse(penX, x * 15 + 1, y * 15 + 1, 13, 13);
								}
								else
								{
									g.DrawLine(penX, x * 15 + 1, y * 15 + 1, x * 15 + 14, y * 15 + 14);
									g.DrawLine(penX, x * 15 + 14, y * 15 + 1, x * 15 + 1, y * 15 + 14);
								}
							}
							break;
						case 4:                     //Выигрышь
							if (player_first_step)
							{
								g.DrawEllipse(penWin, x * 15 + 1, y * 15 + 1, 13, 13);
							}
							else
							{
								g.DrawLine(penWin, x * 15 + 1, y * 15 + 1, x * 15 + 14, y * 15 + 14);
								g.DrawLine(penWin, x * 15 + 14, y * 15 + 1, x * 15 + 1, y * 15 + 14);
							}
							break;
						
						default:
							break;
					}
					
				}
			}
			pictureBox1.Invalidate(); //Перерисовка когда выносим за предела монитора
		}

		//Нажатие на левую кнопку мыши, здесь производится основной расчет
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			//Проверка, не закончена ли игра
			if (!end_game)
			{
				//Ставим в массив игрового поля нолик в зависимости от координат мыши
				if (fields[e.X / 15, e.Y / 15] == 0)
				{
					fields[e.X / 15, e.Y / 15] = 1;
				}
				else
					return;
				//Проводим анализ, не закончена ли игра
				if (!end_analyze())
				{
					//Игра не закончена
					//Ход компьютера
					ii();
					//Проверяем, не закончена ли игра
					if (end_analyze())
					{
						//Игра закончена, выводим сообщение и отрисовываем на экран
						OnPaint();						
						MassageInNewBox("Вы проиграли");
						end_game = true;//Ставим признак конца игры
						return;
					}
				}
				else
				{
					//Игра закончена, выводим сообщение и отрисовываем на экран
					OnPaint();
					MassageInNewBox("Вы выиграли");
					end_game = true;//Ставим признак конца игры
					return;
				}
				//Перерисовка окна
				OnPaint();
			}
			return;
		}

		//Функция вычисления, не закончена ли игра
		public bool end_analyze()
		{
			short tek; //Значение клетки
			int end;//Текущая длина ряда
			int u;//Доп. счетчик

				  //Проход по всему полю (расчет ведется для каждой клетки)
			for (int j = 0; j < size_x; j++)
			{
				for (int i = 0; i < size_x; i++)
				{
					//Пропускаем пустую клетку
					if (fields[i, j] == 0) continue;

					tek = fields[i, j];
					
					/////////////////////////////////////////
					//Смотрим вправо от текущей клетки
					end = 0;
					for (int k = j; k < j + 5; k++)
					{
						if ((k == size_x) || (fields[i, k] != tek))
						{
							//Нет ряда из 5
							break;
						}
						end++;
					}
					if (end == 5)
					{
						//Есть ряд из 5 - конец игры
						for (int k = j; k < j + 5; k++)
						{
							fields[i, k] = (short)(tek + 2); //Заполняем все клетки в ряду значением + 2 для отсветки красным цветом
						}
						return true;
					}

					/////////////////////////////////////////
					//Смотрим вниз и вправо от текущей клетки
					end = 0;
					u = i;
					for (int k = j; k < j + 5; k++)
					{
						if ((k == size_x) || (u == size_x) || (fields[u, k] != tek))
						{
							//Нет ряда из 5
							break;
						}
						end++;
						u++;
					}
					if (end == 5)
					{
						//Есть ряд из 5 - конец игры
						u = i;
						for (int k = j; k < j + 5; k++)
						{
							fields[u, k] = (short)(tek + 2); //Заполняем все клетки в ряду значением + 2 для отсветки красным цветом
							u++;
						}
						return true;
					}
					/////////////////////////////////////////
					//Смотрим вниз и влево от текущей клетки
					end = 0;
					u = i;
					for (int k = j; k > j - 5; k--)
					{
						if ((k == -1) || (u == size_x) || (fields[u, k] != tek))
						{
							//Нет ряда из 5
							break;
						}
						end++;
						u++;
					}
					if (end == 5)
					{
						//Есть ряд из 5 - конец игры
						u = i;
						for (int k = j; k > j - 5; k--)
						{
							fields[u, k] = (short)(tek + 2); //Заполняем все клетки в ряду значением + 2 для отсветки красным цветом
							u++;
						}
						return true;
					}
					/////////////////////////////////////////
					//Смотрим вниз от текущей клетки
					end = 0;
					for (int k = i; k < i + 5; k++)
					{
						if ((k == size_x) || (fields[k, j] != tek))
						{
							//Нет ряда из 5
							break;
						}
						end++;
					}
					if (end == 5)
					{
						//Есть ряд из 5 - конец игры
						for (int k = i; k < i + 5; k++)
						{
							fields[k, j] = (short)(tek + 2); //Заполняем все клетки в ряду значением + 2 для отсветки красным цветом
						}
						return true;
					}
				}
			}
			//Игра не окончена
			return false;
		}


		//Функция расчета действий компьютера
		public void ii()
		{
			float max = -1;//Максимальное значение оценочной функции
			int cur_x = 0, cur_y = 0;//Текущие x и у
			int povtor_num = 0;//Количество повторов одинаковых значений оценочной функции
			int cur_povtor = 0;//Номер текущего повтора
							   //Рассчитываем оценочную функцию для всех клеток
			for (int i = 0; i < size_x; i++)
			{
				for (int j = 0; j < size_x; j++)
				{
					if (fields[i,j] == 0)
					{
						//Расчет оценочной функции
						calc_fields[i,j] = calculate(2, i, j) + calculate(1, i, j) * (float)attack_factor;

						//Еще одна клетка с максимальным значением оценочной функции
						if (calc_fields[i,j] == max)
						{							
							povtor_num++;
						}
						
						//Клетка с максимальным значением оценочной функции
						if (calc_fields[i,j] > max)
						{
							
							max = calc_fields[i,j];
							povtor_num = 0;
							cur_x = i;
							cur_y = j;
						}
					}
				}
			}
			//Проверяем, есть ли вообще свободные клетки на поле
			if (max == -1)
			{
				return;
			}
			//Выбираем куда сделать ход
			if (povtor_num > 0)
			{
				Random rand = new Random();
				//Выбираем куда ходить случайным образом из клеток с одинаковыми значениями оценочной функции
				cur_povtor = rand.Next(povtor_num);//Номер элемента, куда надо ходить
														   //Ищем его по полю
				int buf_povtor = -1;
				for (int i = 0; i < size_x; i++)
				{
					for (int j = 0; j < size_x; j++)
					{
						if (calc_fields[i,j] == max)
						{
							buf_povtor++;
							if (buf_povtor == cur_povtor) //Клетка найдена
							{
								fields[i,j] = 2;//Ставим крестик
								lastX = (short)i;
								lastY = (short)j;
								return;
							}
						}
					}
				}
			}
			else
			{
				//Одна клетка с максимальным знаечением
				fields[cur_x,cur_y] = 2;//Ставим крестик	
				lastX = (short)cur_x;
				lastY = (short)cur_y;
			}
		}

		//Функция расчета оценочной функции
		public float calculate(int id, int x, int y)
		{
			//Подсчет оценочной функции
			//Ставим в массиве временно значение == id
			fields[x,y] = (short)(id);
			int series_length = 0;//Текущая длина ряда
			short pow_st, sum =0;//Общее значение оценочной функции

			///////////Расчет сверху вниз/////////
			//Проход по каждой клетки, которая может входить в ряд
			for (int i = 0; i < 5; i++)
			{
				//Проверка, не вышли ли за границы поля
				if ((x - 4 + i) < 0) continue;
				if ((x + i) > (size_x - 1)) break;
				//Проход по всем возможным рядам, отстоящим от клетки не более чем на 5
				for (int j = 0; j < 5; j++)
				{
					if ((fields[x - 4 + i + j, y] != id) && (fields[x - 4 + i + j, y] != 0))
					{
						//Конец ряда
						series_length = 0;
						break;
					}
					if (fields[x - 4 + i + j,y] != 0) series_length++; //Ряд увеличивается
				}
			
				if (series_length == 5) series_length = 100; //Выигрышная ситуация, ставим большое значение
															 //Плюсуем серию к общей сумме
				pow_st = valuation_factor;
				if (series_length == 100)
				{
					if (id == 2)
						pow_st = 5000;//Большое значение при своем выигрыше
					else
						pow_st = 1000; //Большое значение при выигрыше соперника, но меньшее, чем при своем
				}
				else
				{
					for (int Q = 0; Q < series_length; Q++)//Возводим оценочный коэффициент в степень длины серии
					{
						pow_st *= valuation_factor;
					}
				}
				sum += pow_st;
				series_length = 0;
			}

			///////////Расчет слева направо/////////
			//Проход по каждой клетки, которая может входить в ряд
			for (int i = 0; i < 5; i++)
			{
				//Проверка, не вышли ли за границы поля
				if ((y - 4 + i) < 0) continue;
				if ((y + i) > (size_x - 1)) break;
				//Проход по всем возможным рядам, отстоящим от клетки не более чем на 5
				for (int j = 0; j < 5; j++)
				{
					if ((fields[x,y - 4 + i + j] != id) && (fields[x,y - 4 + i + j] != 0))
					{
						//Конец ряда
						series_length = 0;
						break;
					}
					if (fields[x,y - 4 + i + j] != 0) series_length++; //Ряд увеличивается
				}
				
				if (series_length == 5) series_length = 100; //Выигрышная ситуация, ставим большое значение
															 //Плюсуем серию к общей сумме
				pow_st = valuation_factor;
				if (series_length == 100)
				{
					if (id == 2)
						pow_st = 5000;//Большое значение при своем выигрыше
					else
						pow_st = 1000; //Большое значение при выигрыше соперника, но меньшее, чем при своем
				}
				else
				{
					for (int Q = 0; Q < series_length; Q++)//Возводим оценочный коэффициент в степень длины серии
					{
						pow_st *= valuation_factor;
					}
				}
				sum += pow_st;
				series_length = 0;
			}
			///////////Расчет по диагонали с левого верхнего/////////
			//Проход по каждой клетки, которая может входить в ряд
			for (int i = 0; i < 5; i++)
			{
				//Проверка, не вышли ли за границы поля
				if ((y - 4 + i) < 0) continue;
				if ((x - 4 + i) < 0) continue;
				if ((x + i) > (size_x - 1)) break;
				if ((y + i) > (size_x - 1)) break;
				//Проход по всем возможным рядам, отстоящим от клетки не более чем на 5
				for (int j = 0; j < 5; j++)
				{
					if ((fields[x - 4 + i + j,y - 4 + i + j] != id) && (fields[x - 4 + i + j,y - 4 + i + j] != 0))
					{
						//Конец ряда
						series_length = 0;
						break;
					}
					if (fields[x - 4 + i + j,y - 4 + i + j] != 0) series_length++; //Ряд увеличивается
				}
				
				if (series_length == 5) series_length = 100; //Выигрышная ситуация, ставим большое значение
															 //Плюсуем серию к общей сумме
				pow_st = valuation_factor;
				if (series_length == 100)
				{
					if (id == 2)
						pow_st = 5000;//Большое значение при своем выигрыше
					else
						pow_st = 1000; //Большое значение при выигрыше соперника, но меньшее, чем при своем
				}
				else
				{
					for (int Q = 0; Q < series_length; Q++)//Возводим оценочный коэффициент в степень длины серии
					{
						pow_st *= valuation_factor;
					}
				}
				sum += pow_st;
				series_length = 0;
			}
			///////////Расчет по диагонали с левого нижнего/////////
			//Проход по каждой клетки, которая может входить в ряд
			for (int i = 0; i < 5; i++)
			{
				//Проверка, не вышли ли за границы поля
				if ((y - 4 + i) < 0) continue;
				if ((x + 4 - i) > (size_x - 1)) continue;
				if ((x - i) < 0) break;
				if ((y + i) > (size_x - 1)) break;
				//Проход по всем возможным рядам, отстоящим от клетки не более чем на 5
				for (int j = 0; j < 5; j++)
				{
					if ((fields[x + 4 - i - j,y - 4 + i + j] != id) && (fields[x + 4 - i - j,y - 4 + i + j] != 0))
					{
						//Конец ряда
						series_length = 0;
						break;
					}
					if (fields[x + 4 - i - j,y - 4 + i + j] != 0) series_length++; //Ряд увеличивается
				}
				
				if (series_length == 5) series_length = 100; //Выигрышная ситуация, ставим большое значение
															 //Плюсуем серию к общей сумме
				pow_st = valuation_factor;
				if (series_length == 100)
				{
					if (id == 2)
						pow_st = 5000;//Большое значение при своем выигрыше
					else
						pow_st = 1000; //Большое значение при выигрыше соперника, но меньшее, чем при своем
				}
				else
				{
					for (int Q = 0; Q < series_length; Q++)//Возводим оценочный коэффициент в степень длины серии
					{
						pow_st *= valuation_factor;
					}
				}
				sum += pow_st;
				series_length = 0;
			}
			//Возвращаем исходное значение
			fields[x,y] = 0;
			return sum;
		}


		//Это всё загрузка
		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(image, 0, 0, image.Width, image.Height);
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			g = Graphics.FromImage(image);
			fields = new short[size_x, size_x];
			calc_fields = new float[size_x, size_x];
			OnPaint();
		}

		//Для вывода сообщений в новое окно
		public void MassageInNewBox(string s)
		{
			//Создаем новую форму
			Form form2 = new Form();
			form2.Text = s;
			// Size the form to be 300 pixels in height and width.
			form2.Size = new Size(270,10);
			// Display the form in the center of the screen.
			form2.StartPosition = FormStartPosition.CenterScreen;

			// Display the form as a modal dialog box.
			form2.ShowDialog();
		}

		//Новая игра
		public void new_game()
		{
			//Пересоздание массива
			short[,] Newfields = new short[size_x, size_x];
			fields = Newfields;
			float[,] New_calc_fields = new float[size_x, size_x];
			calc_fields = New_calc_fields;
			//Сбрасываем флаг начала игры
			end_game = false;

			//Проверяем, не должен ли компьютер ходить первым
			if (!player_first_step)
				ii();
		}

		//Изменение размеров окна
		public void resize_window()
		{
			this.Size = new System.Drawing.Size(15 * size_x + 17, 15 * size_x + 64);
		}

		//Если размер окна 10х10
		private void x10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//снимаем галочки
			switch (size_x)
			{
				case 19:
					x19ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 30:
					x30ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 40:
					x40ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				default:
					break;
			}
			x10ToolStripMenuItem.CheckState = CheckState.Checked;

			size_x = 10;
			new_game();
			resize_window();
			image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			g = Graphics.FromImage(image);
			OnPaint();

		}

		//Если размер окна 19х19
		private void x19ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//снимаем галочки
			switch (size_x)
			{
				case 10:
					x10ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 30:
					x30ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 40:
					x40ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				default:
					break;
			}
			x19ToolStripMenuItem.CheckState = CheckState.Checked;

			size_x = 19;
			new_game();
			resize_window();
			image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			g = Graphics.FromImage(image);
			OnPaint();
		}

		//Если размер окна 30х30
		private void x30ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//снимаем галочки
			switch (size_x)
			{
				case 10:
					x10ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 19:
					x19ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 40:
					x40ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				default:
					break;
			}
			x30ToolStripMenuItem.CheckState = CheckState.Checked;

			size_x = 30;
			new_game();
			resize_window();
			image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			g = Graphics.FromImage(image);
			OnPaint();
		}

		//Если размер окна 40х40
		private void x40ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//снимаем галочки
			switch (size_x)
			{
				case 10:
					x10ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 19:
					x19ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				case 30:
					x30ToolStripMenuItem.CheckState = CheckState.Unchecked;
					break;
				default:
					break;
			}
			x40ToolStripMenuItem.CheckState = CheckState.Checked;

			size_x = 40;			
			new_game();
			resize_window();
			image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			g = Graphics.FromImage(image);
			OnPaint();
		}

		//В меню вабрали тактику атаки
		private void атакаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			оборонаToolStripMenuItem.CheckState = CheckState.Unchecked;
			атакаToolStripMenuItem.CheckState = CheckState.Checked;
			attack_factor = 3;
			//Старт новой игры
			new_game();
			//Перерисовка окна
			OnPaint();
		}

		//В меню вабрали тактику обороны
		private void оборонаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			оборонаToolStripMenuItem.CheckState = CheckState.Checked;
			атакаToolStripMenuItem.CheckState = CheckState.Unchecked;
			attack_factor = 2;
			//Старт новой игры
			new_game();
			//Перерисовка окна
			OnPaint();
		}

		//В меню вабрали первый ход за человеком
		private void человекаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			компьютераToolStripMenuItem.CheckState = CheckState.Unchecked;
			человекаToolStripMenuItem.CheckState = CheckState.Checked;

			player_first_step = true;
			//Старт новой игры
			new_game();
			//Перерисовка окна
			OnPaint();
		}

		//В меню вабрали первый ход за компьютером
		private void компьютераToolStripMenuItem_Click(object sender, EventArgs e)
		{
			компьютераToolStripMenuItem.CheckState = CheckState.Checked;
			человекаToolStripMenuItem.CheckState = CheckState.Unchecked;

			player_first_step = false;
			//Старт новой игры
			new_game();
			//Перерисовка окна
			OnPaint();
		}


		//Нажали кнопку в меню "новая игра"
		private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new_game(); //Функция начала новой игры
			OnPaint();
		}

		//Нажали кнопку в меню "выход"
		private void выходToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
