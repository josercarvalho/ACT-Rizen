import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/pages/models/Clientes';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit{

  inputdata:any
  cliente!: Cliente;

  constructor(@Inject(MAT_DIALOG_DATA) public data:any, private clienteService: ClienteService, private router: Router, private ref:MatDialogRef<ExcluirComponent>){}

  ngOnInit(): void {
      this.inputdata = this.data;

      this.clienteService.GetCliente(this.inputdata.id).subscribe(data => {
          this.cliente = data;
      });
  }

  excluir(){
    this.clienteService.ExcluirCliente(this.inputdata.id).subscribe(data => {
       this.ref.close();
       window.location.reload();
    });
  }

}
