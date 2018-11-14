/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.Toolkit;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author evafinn
 */
public class ClientFrame extends JFrame {
    JPanel panel;
    public ClientFrame()
	{
		super();
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setTitle("TicTacToe");
		Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();
                int height = screenSize.height;
                int width = screenSize.width;
                this.setSize(width/2, height/2);
		this.setLayout(new BorderLayout());
		panel = new Panel();
		this.add(panel, BorderLayout.CENTER);
                this.setLocationRelativeTo(null);
		this.setVisible(true);
	}
    
}
