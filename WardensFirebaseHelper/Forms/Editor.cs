﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WardensFirebaseHelper.Files;

namespace WardensFirebaseHelper.Forms {
    public partial class Editor : Form {
        FirebaseInterface dataBaseInterface = new FirebaseInterface(Application.StartupPath + "\\dbLocal.json");
        public Editor() {            
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }
    }
}

