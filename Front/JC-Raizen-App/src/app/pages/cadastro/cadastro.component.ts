import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../models/Clientes';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})

export class CadastroComponent implements OnInit {

  btnAcao = "Cadastrar!";
  btnTitulo = "Cadastrar Cliente!";

  constructor(private clienteService : ClienteService, private router: Router,
    public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  createCliente(cliente: Cliente){

       this.clienteService.CreateCliente(cliente).subscribe((data) => {
        this.matSnackBar.open("Salvo com sucesso!", "", {
          duration: 5000
        })
        this.router.navigate(['/']);
      })
  }
}
