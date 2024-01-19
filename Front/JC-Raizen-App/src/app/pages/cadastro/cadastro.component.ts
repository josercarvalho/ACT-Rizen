import { Component, OnInit } from '@angular/core';
import { ClienteService } from 'src/app/services/cliente.service';
import { Cliente } from '../models/Clientes';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})

export class CadastroComponent implements OnInit {

  btnAcao = "Cadastrar!";
  btnTitulo = "Cadastrar Cliente!";

  constructor(private clienteService : ClienteService, private router: Router) {
  }

  ngOnInit(): void {
  }

  createCliente(cliente: Cliente){

       this.clienteService.CreateCliente(cliente).subscribe((data) => {
          this.router.navigate(['/']);
       })
  }
}
