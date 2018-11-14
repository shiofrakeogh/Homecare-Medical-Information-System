/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;

import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;

/**
 *
 * @author evafinn
 */
public class GameScreen extends JPanel {
    JButton buttons[] = new JButton[9];
    int turn = 0;
    
    public GameScreen(){
        setLayout(new GridLayout(4,3));
        initBtns();
        
    }
    
    public void initBtns(){
        for(int i = 0; i <= 8; i++)
        {
            buttons[i] = new JButton();
            buttons[i].setText("");
            buttons[i].addActionListener(new buttonListener());
            
            add(buttons[i]);
           
        }
    }
    
    public void resetButtons(){
        for(int i = 0; i <= 8; i++)
        {
            buttons[i].setText("");
        }
    }

    class buttonListener implements ActionListener {

        public buttonListener() {
            
        }

        @Override
        public void actionPerformed(ActionEvent e){
                JButton buttonClicked = (JButton)e.getSource(); //get the particular button that was clicked
                if(turn%2 == 0)
                    buttonClicked.setText("X");
                else
                    buttonClicked.setText("O");

                if(checkForWin() == true){
                    JOptionPane.showConfirmDialog(null, "Game Over.");
                    resetButtons();
                }

                turn++;

            }

            public boolean checkForWin(){
                /**   Reference: the button array is arranged like this as the board
                 *      0 | 1 | 2
                 *      3 | 4 | 5
                 *      6 | 7 | 8
                 */
                //horizontal win check
                if( checkAdjacent(0,1) && checkAdjacent(1,2) ) 
                    return true;
                else if( checkAdjacent(3,4) && checkAdjacent(4,5) )
                    return true;
                else if ( checkAdjacent(6,7) && checkAdjacent(7,8))
                    return true;

                //vertical win check
                else if ( checkAdjacent(0,3) && checkAdjacent(3,6))
                    return true;  
                else if ( checkAdjacent(1,4) && checkAdjacent(4,7))
                    return true;
                else if ( checkAdjacent(2,5) && checkAdjacent(5,8))
                    return true;

                //diagonal win check
                else if ( checkAdjacent(0,4) && checkAdjacent(4,8))
                    return true;  
                else if ( checkAdjacent(2,4) && checkAdjacent(4,6))
                    return true;
                else 
                    return false;   
            }

            public boolean checkAdjacent(int a, int b){
                return buttons[a].getText().equals(buttons[b].getText()) && !buttons[a].getText().equals("");
            }

        }
    
}
