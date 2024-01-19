import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/Clientes';
import { ClienteService } from 'src/app/services/cliente.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})

export class DetalhesComponent implements OnInit{

  cliente?: Cliente;
  id!:number;

 constructor(private clienteService: ClienteService, private route: ActivatedRoute, private router : Router) {

 }

 ngOnInit(): void {

     this.id =  Number(this.route.snapshot.paramMap.get("id"));

     this.clienteService.GetCliente( this.id).subscribe((data) => {
        const dados = data;

        dados.dataNascimento = new Date(dados.dataNascimento!).toLocaleDateString("pt-BR");

        this.cliente = dados;
     });
 }
}
