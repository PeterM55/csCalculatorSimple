using System;

namespace Calculator55
{
    partial class CalcForm
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.TextBox outPutTb;
        //private System.Windows.Forms.Label helloWorldLabel;

        //bottom left section
        private System.Windows.Forms.Button[] num;
        private System.Windows.Forms.Button decimalButton; //was planning to use this but didnt yet

        //bottom right section
        private System.Windows.Forms.Button leftBracketButton;
        private System.Windows.Forms.Button rightBracketButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button powerButton;
        private System.Windows.Forms.Button sqrtButton;
        private System.Windows.Forms.Button submitb;

        private void InitializeComponent()
        {
            this.textField = new System.Windows.Forms.TextBox();
            this.outPutTb = new System.Windows.Forms.TextBox();

            //this.helloWorldLabel = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.Button[10];

            this.leftBracketButton = new System.Windows.Forms.Button();
            this.rightBracketButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.powerButton = new System.Windows.Forms.Button();
            this.sqrtButton = new System.Windows.Forms.Button();
            this.submitb = new System.Windows.Forms.Button();

            this.SuspendLayout();


            // text field
            this.textField.Location = new System.Drawing.Point(12, 12);
            this.textField.Name = "textField";
            this.textField.Size = new System.Drawing.Size(280, 50);
            this.textField.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.textField.TabIndex = 0;
            //this.textField.Enter += new System.EventHandler(this.submit);
            this.textField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFieldKp);
            //this.textField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPosition_KeyPress);
            this.Controls.Add(this.textField);

            // text box - outputTb
            this.outPutTb.Location = new System.Drawing.Point(12, 70);
            this.outPutTb.Name = "outPutTb";
            this.outPutTb.Size = new System.Drawing.Size(280, 50);
            this.outPutTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.outPutTb.TabIndex = 11;
            //this.textField.Enter += new System.EventHandler(this.submit);
            this.outPutTb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFieldKp);
            //this.textField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPosition_KeyPress);
            this.Controls.Add(this.outPutTb);


            int startPosX = 200;
            int startPosY = 125;
            int xIncriment = 50;
            int yIncriment = 50;

            //leftBracketButton
            this.leftBracketButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.leftBracketButton.Location = new System.Drawing.Point(startPosX, startPosY);
            this.leftBracketButton.Name = "leftBracketButton";
            this.leftBracketButton.Size = new System.Drawing.Size(40, 40);
            //this.leftBracketButton.TabIndex = 2;
            this.leftBracketButton.Text = "(";
            this.leftBracketButton.Click += new System.EventHandler(this.leftBracketButtonPress);
            this.Controls.Add(this.leftBracketButton);

            //rightBracketButton
            this.rightBracketButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.rightBracketButton.Location = new System.Drawing.Point(startPosX + xIncriment, startPosY);
            this.rightBracketButton.Name = "rightBracketButton";
            this.rightBracketButton.Size = new System.Drawing.Size(40, 40);
            //this.rightBracketButton.TabIndex = 2;
            this.rightBracketButton.Text = ")";
            this.rightBracketButton.Click += new System.EventHandler(this.rightBracketButtonPress);
            this.Controls.Add(this.rightBracketButton);

            //multiplyButton
            this.multiplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.multiplyButton.Location = new System.Drawing.Point(startPosX, startPosY + yIncriment);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(40, 40);
            //this.multiplyButton.TabIndex = 2;
            this.multiplyButton.Text = "*";
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButtonPress);
            this.Controls.Add(this.multiplyButton);

            //divideButton
            this.divideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.divideButton.Location = new System.Drawing.Point(startPosX + xIncriment, startPosY + yIncriment);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(40, 40);
            //this.divideButton.TabIndex = 2;
            this.divideButton.Text = "/";
            this.divideButton.Click += new System.EventHandler(this.divideButtonPress);
            this.Controls.Add(this.divideButton);

            //addButton
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.addButton.Location = new System.Drawing.Point(startPosX, startPosY + yIncriment * 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(40, 40);
            //this.addButton.TabIndex = 2;
            this.addButton.Text = "+";
            this.addButton.Click += new System.EventHandler(this.addButtonPress);
            this.Controls.Add(this.addButton);

            // minusButton
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.minusButton.Location = new System.Drawing.Point(startPosX + xIncriment, startPosY + yIncriment * 2);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(40, 40);
            //this.minusButton.TabIndex = 2;
            this.minusButton.Text = "-";
            this.minusButton.Click += new System.EventHandler(this.minusButtonPress);
            this.Controls.Add(this.minusButton);

            // powerButton
            this.powerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.powerButton.Location = new System.Drawing.Point(startPosX, startPosY + yIncriment * 3);
            this.powerButton.Name = "powerButton";
            this.powerButton.Size = new System.Drawing.Size(40, 40);
            this.powerButton.Text = "^";
            this.powerButton.Click += new System.EventHandler(this.powerButtonPress);
            this.Controls.Add(this.powerButton);
            
            // sqrtButton
            this.sqrtButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20);
            this.sqrtButton.Location = new System.Drawing.Point(startPosX + xIncriment, startPosY + yIncriment * 3);
            this.sqrtButton.Name = "sqrtButton";
            this.sqrtButton.Size = new System.Drawing.Size(40, 40);
            this.sqrtButton.Text = "√";
            this.sqrtButton.Click += new System.EventHandler(this.sqrtButtonPress);
            this.Controls.Add(this.sqrtButton);

            // submitb
            this.submitb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitb.Location = new System.Drawing.Point(75, 275);
            this.submitb.Name = "submitb";
            this.submitb.Size = new System.Drawing.Size(90, 40);
            this.submitb.TabIndex = 2;
            this.submitb.Text = "=";
            this.submitb.Click += new System.EventHandler(this.equalsButtonPress);
            this.Controls.Add(this.submitb);


            for (int i = 0; i < 10; i++)
            {
                //this.num[i] = new System.Windows.Forms.Button();
                this.num[i] = new System.Windows.Forms.Button();
                if (i == 0)
                {
                    
                    this.num[0].Location = new System.Drawing.Point(50 * (((-2 - 1) % 3))+25, (3 - ((-2 - 1) / 3)) * 50 + 75); // x,y
                    i = 0;
                }
                else
                {
                    //Console.WriteLine(i);
                    //this.num[i] = new System.Windows.Forms.Button();
                    this.num[i].Location = new System.Drawing.Point(50 * (((i - 1) % 3)) + 25, (3 - ((i - 1) / 3)) * 50 + 75);
                }

                this.num[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.num[i].Margin = new System.Windows.Forms.Padding(2);
                this.num[i].Name = "num" + i.ToString();
                this.num[i].Size = new System.Drawing.Size(40, 40);
                this.num[i].TabIndex = i + 1;
                this.num[i].Text = i.ToString();
                this.num[i].UseVisualStyleBackColor = true;
                this.Controls.Add(this.num[i]);
                //if (i == 0) i = -2;
            }

            this.num[0].Click += new System.EventHandler(this.click0);
            this.num[1].Click += new System.EventHandler(this.click1);
            this.num[2].Click += new System.EventHandler(this.click2);
            this.num[3].Click += new System.EventHandler(this.click3);
            this.num[4].Click += new System.EventHandler(this.click4);
            this.num[5].Click += new System.EventHandler(this.click5);
            this.num[6].Click += new System.EventHandler(this.click6);
            this.num[7].Click += new System.EventHandler(this.click7);
            this.num[8].Click += new System.EventHandler(this.click8);
            this.num[9].Click += new System.EventHandler(this.click9);

            // 
            // calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 350); //x,y
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "calculator";
            this.Text = "Calculator55";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

