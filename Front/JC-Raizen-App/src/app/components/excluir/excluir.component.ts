import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/pages/models/Clientes';
import { ClienteService } from 'src/app/services/cliente.service';

import {MatButtonModule} from '@angular/material/button';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css'],
  standalone: true,
  imports: [MatButtonModule],
})
export class ExcluirComponent implements OnInit{

  inputdata:any
  cliente!: Cliente;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data:any,
    private clienteService: ClienteService,
    private router: Router,
    private ref:MatDialogRef<ExcluirComponent>,
    public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
      this.inputdata = this.data;

      this.clienteService.GetCliente(this.inputdata.id).subscribe(data => {
        const dados = data;
        dados.dataNascimento = new Date(dados.dataNascimento!).toLocaleDateString("pt-BR");
          this.cliente = dados;
      });
  }

  excluir(){
    this.clienteService.ExcluirCliente(this.inputdata.id).subscribe(data => {
      this.matSnackBar.open("Salvo com sucesso!", "", {
        duration: 5000
      })
       this.ref.close();
       window.location.reload();
    });
  }

  onVoltarClick(): void {
    this.ref.close();
  }

}
