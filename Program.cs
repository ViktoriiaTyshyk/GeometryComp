using System;
using System.Drawing;
using System.Windows.Forms;

public class CircleForm : Form
{
    private Timer timer;
    private int radius1 = 50; 
    private int radius2 = 80; 
    private int x1, x2; 
    private int y; 
    private int speed1 = 12; 
    private int speed2 = 5; 
    private bool isOneDirection = true; 

    public CircleForm()
    {
        this.Text = "Рух кіл";
        this.Size = new Size(800, 400);
        this.DoubleBuffered = true;

        x1 = 50;
        x2 = 650;
        y = this.ClientSize.Height / 2;

        timer = new Timer();
        timer.Interval = 30; 
        timer.Tick += new EventHandler(OnTick);
        timer.Start();

        Button directionButton = new Button { Text = "Змінити напрямок", Dock = DockStyle.Top };
        directionButton.Click += (s, e) => { isOneDirection = !isOneDirection; };
        this.Controls.Add(directionButton);
    }

    private void OnTick(object sender, EventArgs e)
    {
        if (isOneDirection)
        {
            x1 += speed1;
            x2 += speed2;

            if (x1 + radius1 >= x2 - radius2)
            {
                timer.Stop(); 
            }
        }
        else
        {
            x1 += speed1;
            x2 -= speed2;

            if (x1 + radius1 >= x2 - radius2)
            {
                timer.Stop(); 
            }
        }

        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.FillEllipse(Brushes.Blue, x1 - radius1, y - radius1, radius1 * 2, radius1 * 2);

        g.FillEllipse(Brushes.Red, x2 - radius2, y - radius2, radius2 * 2, radius2 * 2);
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new CircleForm());
    }
}
