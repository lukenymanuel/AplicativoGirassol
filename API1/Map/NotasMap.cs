using API.Model;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class NotaMap : BaseMap<Nota>
    {
        public NotaMap() : base("tb_nota")
        {
        }

        public override void Configure(EntityTypeBuilder<Nota> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Valor).HasColumnName("valor");
            builder.Property(x => x.AlunoId).HasColumnName("aluno_id").IsRequired();
            builder.Property(x => x.ProfessorId).HasColumnName("professor_id").IsRequired();
            builder.Property(x => x.DisciplinaId).HasColumnName("disciplina_id").IsRequired();
            builder.Property(x => x.Prova).HasColumnName("prova");
            builder.Property(x => x.Trimestre).HasColumnName("trimestre");

            builder.HasOne(x => x.Aluno).WithMany().HasForeignKey(x => x.AlunoId);
            builder.HasOne(x => x.Professor).WithMany().HasForeignKey(x => x.ProfessorId);
            builder.HasOne(x => x.Disciplina).WithMany().HasForeignKey(x => x.DisciplinaId);
        }
    }
}
