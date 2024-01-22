import { ClienteService } from './../../services/cliente.service';
import { Component, OnInit } from '@angular/core';
import { Cliente } from '../models/Clientes';
import { MatDialog } from '@angular/material/dialog';
import { ExcluirComponent } from 'src/app/components/excluir/excluir.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  clientes: Cliente[] = [];
  clientesGeral: Cliente[] = [];
  columnsToDisplay = ['Nome', 'E-mail', 'Data de Nascimento', 'CEP', 'Ações', 'Teste'];

  constructor(private clienteService : ClienteService, public matDialog: MatDialog) { }

  ngOnInit(): void {
    this.clienteService.GetClientes().subscribe((data) => {

      const dados = data;
      dados.map((item) => {
        item.dataNascimento = new Date(item.dataNascimento!).toLocaleDateString('pt-BE');
      });

      console.log(dados);
      this.clientesGeral = dados;
      this.clientes = dados;

    })
  }

  search(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.clientes = this.clientesGeral.filter(funcionario => {
      return funcionario.nome.toLowerCase().includes(value);
    })
  }

  openDialog(id : number){
    const dialogRef = this.matDialog.open(ExcluirComponent,{
      width: '350px',
      height: '350px',
      data: {
        id: id
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}
