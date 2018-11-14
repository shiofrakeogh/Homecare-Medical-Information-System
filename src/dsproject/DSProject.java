/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dsproject;
import javax.swing.SwingUtilities;
import tictactoegame.TTTWebService;
import tictactoegame.TTTWebService_Service;


/**
 *
 * @author Shíofra
 */
public class DSProject {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        TTTWebService_Service link = new TTTWebService_Service();
        TTTWebService proxy = link.getTTTWebServicePort();
        
        SwingUtilities.invokeLater(() -> {
            ClientFrame frame = new ClientFrame();
//            wnd.setVisible(true);
        });
        
        
    }
    
}
