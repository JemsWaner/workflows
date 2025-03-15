public class MaquinaDeCafe {  
    private Cafetera cafetera;  
    private Vaso vasosPequeno;  
    private Vaso vasosMediano;  
    private Vaso vasosGrande;  
    private Azucarero azucarero;  

    public void setCafetera(Cafetera cafetera) {  
        this.cafetera = cafetera;  
    }  

    public void setVasosPequeno(Vaso vaso) {  
        this.vasosPequeno = vaso;  
    }  

    public void setVasosMediano(Vaso vaso) {  
        this.vasosMediano = vaso;  
    }  

    public void setVasosGrande(Vaso vaso) {  
        this.vasosGrande = vaso;  
    }  

    public void setAzucarero(Azucarero azucarero) {  
        this.azucarero = azucarero;  
    }  

    public Vaso getTipoDeVaso(String tipo) {  
        if (tipo.equalsIgnoreCase("pequeno")) return vasosPequeno;  
        if (tipo.equalsIgnoreCase("mediano")) return vasosMediano;  
        if (tipo.equalsIgnoreCase("grande")) return vasosGrande;  
        return null;  
    }  

    public String getVasoDeCafe(Vaso vaso, int cantidadCafe, int cantidadAzucar) {  
        if (!cafetera.hasCafe(cantidadCafe)) {  
            return "No hay Cafe";  
        }  
        if (!azucarero.hasAzucar(cantidadAzucar)) {  
            return "No hay Azucar";  
        }  
        if (!vaso.hasVasos(1)) {  
            return "No hay Vasos";  
        }  
        cafetera.giveCafe(cantidadCafe);  
        azucarero.giveAzucar(cantidadAzucar);  
        vaso.giveVasos(1);  
        return "Felicitaciones";  
    }  
}  
public class Cafetera {  
    private int cantidadCafe;  

    public Cafetera(int cantidadCafe) {  
        this.cantidadCafe = cantidadCafe;  
    }  

    public boolean hasCafe(int cantidad) {  
        return cantidadCafe >= cantidad;  
    }  

    public void giveCafe(int cantidad) {  
        cantidadCafe -= cantidad;  
    }  

    public int getCantidadCafe() {  
        return cantidadCafe;  
    }  
}  

public class Vaso {  
    private int cantidadVasos;  

    public Vaso(int cantidadVasos) {  
        this.cantidadVasos = cantidadVasos;  
    }  

    public boolean hasVasos(int cantidad) {  
        return cantidadVasos >= cantidad;  
    }  

    public void giveVasos(int cantidad) {  
        cantidadVasos -= cantidad;  
    }  

    public int getCantidadVasos() {  
        return cantidadVasos;  
    }  
}  

public class Azucarero {  
    private int cantidadAzucar;  

    public Azucarero(int cantidadAzucar) {  
        this.cantidadAzucar = cantidadAzucar;  
    }  

    public boolean hasAzucar(int cantidad) {  
        return cantidadAzucar >= cantidad;  
    }  

    public void giveAzucar(int cantidad) {  
        cantidadAzucar -= cantidad;  
    }  

    public int getCantidadAzucar() {  
        return cantidadAzucar;  
    }  
}  

import static org.junit.Assert.*;  
import org.junit.Before;  
import org.junit.Test;  

public class TestMaquinaDeCafe {  
    private Cafetera cafetera;  
    private Vaso vasosPequeno;  
    private Azucarero azucarero;  
    private MaquinaDeCafe maquinaDeCafe;  

    @Before  
    public void setUp() {  
        cafetera = new Cafetera(50);  
        vasosPequeno = new Vaso(5);  
        azucarero = new Azucarero(20);  
        maquinaDeCafe = new MaquinaDeCafe();  
        maquinaDeCafe.setCafetera(cafetera);  
        maquinaDeCafe.setVasosPequeno(vasosPequeno);  
        maquinaDeCafe.setAzucarero(azucarero);  
    }  

    @Test  
    public void deberiaDevolverFelicitaciones() {  
        String resultado = maquinaDeCafe.getVasoDeCafe(vasosPequeno, 5, 2);  
        assertEquals("Felicitaciones", resultado);  
    }  

    @Test  
    public void deberiaDevolverNoHayCafe() {  
        cafetera.giveCafe(50); // Vaciar la cafetera  
        String resultado = maquinaDeCafe.getVasoDeCafe(vasosPequeno, 5, 2);  
        assertEquals("No hay Cafe", resultado);  
    }  

    @Test  
    public void deberiaDevolverNoHayAzucar() {  
        azucarero.giveAzucar(20); // Vaciar el azucarero  
        String resultado = maquinaDeCafe.getVasoDeCafe(vasosPequeno, 5, 2);  
        assertEquals("No hay Azucar", resultado);  
    }  

    @Test  
    public void deberiaDevolverNoHayVasos() {  
        vasosPequeno.giveVasos(5); // Vaciar vasos  
        String resultado = maquinaDeCafe.getVasoDeCafe(vasosPequeno, 5, 2);  
        assertEquals("No hay Vasos", resultado);  
    }  
}  
