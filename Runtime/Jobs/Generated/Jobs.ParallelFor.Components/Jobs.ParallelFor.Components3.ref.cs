namespace ME.BECS.Jobs {
    
    using static Cuts;
    using Unity.Jobs;
    using Unity.Jobs.LowLevel.Unsafe;
    using Unity.Collections.LowLevel.Unsafe;
    using Unity.Burst;

    [JobProducerType(typeof(JobParallelForComponentsExtensions.JobProcess<,,,>))]
    [System.Obsolete("IJobParallelForComponents is deprecated, use .AsParallel() API instead.")]
    public interface IJobParallelForComponents<T0,T1,T2> : IJobParallelForComponentsBase where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase {
        void Execute(in JobInfo jobInfo, in Ent ent, ref T0 c0,ref T1 c1,ref T2 c2);
    }
    
    #pragma warning disable
    public static unsafe partial class QueryParallelScheduleExtensions {
        
        public static JobHandle Schedule<T, T0,T1,T2>(this QueryBuilder builder, in T job = default) where T : struct, IJobParallelForComponents<T0,T1,T2> where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase {
            builder.With<T0>(); builder.With<T1>(); builder.With<T2>();
            builder.builderDependsOn = builder.SetEntities(builder.commandBuffer, builder.builderDependsOn);
            builder.builderDependsOn = job.Schedule<T, T0,T1,T2>(in builder.commandBuffer, builder.parallelForBatch, builder.isUnsafe, builder.builderDependsOn);
            builder.builderDependsOn = builder.Dispose(builder.builderDependsOn);
            return builder.builderDependsOn;
        }
        
        public static JobHandle Schedule<T, T0,T1,T2>(this Query staticQuery, in T job, in SystemContext context) where T : struct, IJobParallelForComponents<T0,T1,T2> where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase {
            return staticQuery.Schedule<T, T0,T1,T2>(in job, in context.world, context.dependsOn);
        }
        
        public static JobHandle Schedule<T, T0,T1,T2>(this Query staticQuery, in T job, in World world, JobHandle dependsOn = default) where T : struct, IJobParallelForComponents<T0,T1,T2> where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase {
            var state = world.state;
            var query = API.MakeStaticQuery(QueryContext.Create(state, world.id), dependsOn).FromQueryData(state, world.id, state->queries.GetPtr(state, staticQuery.id));
            return query.Schedule<T, T0,T1,T2>(in job);
        }

        public static JobHandle Schedule<T, T0,T1,T2>(this QueryBuilderDisposable staticQuery, in T job) where T : struct, IJobParallelForComponents<T0,T1,T2> where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase {
            staticQuery.builderDependsOn = job.Schedule<T, T0,T1,T2>(in staticQuery.commandBuffer, staticQuery.parallelForBatch, staticQuery.isUnsafe, staticQuery.builderDependsOn);
            staticQuery.builderDependsOn = staticQuery.Dispose(staticQuery.builderDependsOn);
            return staticQuery.builderDependsOn;
        }
        
    }
    
    public static partial class EarlyInit {
        public static void DoParallelForComponents<T, T0,T1,T2>()
                where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase
                where T : struct, IJobParallelForComponents<T0,T1,T2> => JobParallelForComponentsExtensions.JobEarlyInitialize<T, T0,T1,T2>();
    }
    #pragma warning restore

    #pragma warning disable
    public static unsafe partial class JobParallelForComponentsExtensions {
    
        public static void JobEarlyInitialize<T, T0,T1,T2>()
            where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase
            where T : struct, IJobParallelForComponents<T0,T1,T2> => JobProcess<T, T0,T1,T2>.Initialize();

        public static JobHandle Schedule<T, T0,T1,T2>(this T jobData, in CommandBuffer* buffer, uint innerLoopBatchCount, bool unsafeMode, JobHandle dependsOn = default)
            where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase
            where T : struct, IJobParallelForComponents<T0,T1,T2> {
            
            //dependsOn = new StartParallelJob() {
            //                buffer = buffer,
            //            }.ScheduleSingle(dependsOn);
                        
            if (innerLoopBatchCount == 0u) innerLoopBatchCount = JobUtils.GetScheduleBatchCount(buffer->count);

            buffer->sync = false;
            void* data = null;
            #if ENABLE_UNITY_COLLECTIONS_CHECKS && ENABLE_BECS_COLLECTIONS_CHECKS
            data = CompiledJobs<T>.Get(_address(ref jobData), buffer, unsafeMode, ScheduleMode.Parallel);
            var parameters = new JobsUtility.JobScheduleParameters(data, unsafeMode == true ? JobReflectionUnsafeData<T>.data.Data : JobReflectionData<T>.data.Data, dependsOn, ScheduleMode.Parallel);
            #else
            var dataVal = new JobData<T, T0,T1,T2>() {
                scheduleMode = ScheduleMode.Parallel,
                jobData = jobData,
                buffer = buffer,
                c0 = buffer->state->components.GetRW<T0>(buffer->state, buffer->worldId),c1 = buffer->state->components.GetRW<T1>(buffer->state, buffer->worldId),c2 = buffer->state->components.GetRW<T2>(buffer->state, buffer->worldId),
            };
            data = _address(ref dataVal);
            var parameters = new JobsUtility.JobScheduleParameters(data, JobReflectionData<T>.data.Data, dependsOn, ScheduleMode.Parallel);
            #endif
            
            return JobsUtility.ScheduleParallelForDeferArraySize(ref parameters, (int)innerLoopBatchCount, (byte*)buffer, null);
            
        }

        private struct JobData<T, T0,T1,T2>
            where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase
            where T : struct {
            public ScheduleMode scheduleMode;
            [NativeDisableUnsafePtrRestriction]
            public T jobData;
            [NativeDisableUnsafePtrRestriction]
            public CommandBuffer* buffer;
            public RefRW<T0> c0;public RefRW<T1> c1;public RefRW<T2> c2;
        }

        internal struct JobProcess<T, T0,T1,T2>
            where T0 : unmanaged, IComponentBase where T1 : unmanaged, IComponentBase where T2 : unmanaged, IComponentBase
            where T : struct, IJobParallelForComponents<T0,T1,T2> {

            [BurstDiscard]
            public static void Initialize() {
                if (JobReflectionData<T>.data.Data == System.IntPtr.Zero) {
                    #if ENABLE_UNITY_COLLECTIONS_CHECKS && ENABLE_BECS_COLLECTIONS_CHECKS
                    JobReflectionData<T>.data.Data = JobsUtility.CreateJobReflectionData(CompiledJobs<T>.GetJobType(false), typeof(T), (ExecuteJobFunction)Execute);
                    JobReflectionUnsafeData<T>.data.Data = JobsUtility.CreateJobReflectionData(CompiledJobs<T>.GetJobType(true), typeof(T), (ExecuteJobFunction)Execute);
                    #else
                    JobReflectionData<T>.data.Data = JobsUtility.CreateJobReflectionData(typeof(JobData<T, T0,T1,T2>), typeof(T), (ExecuteJobFunction)Execute);
                    #endif
                }
            }

            private delegate void ExecuteJobFunction(ref JobData<T, T0,T1,T2> jobData, System.IntPtr bufferPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

            private static void Execute(ref JobData<T, T0,T1,T2> jobData, System.IntPtr bufferPtr, System.IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex) {

                var jobInfo = JobInfo.Create(jobData.buffer->worldId);
                jobInfo.count = jobData.buffer->count;
                while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out var begin, out var end) == true) {
                    
                    jobData.buffer->BeginForEachRange((uint)begin, (uint)end);
                    for (uint i = (uint)begin; i < end; ++i) {
                        jobInfo.index = i;
                        var entId = *(jobData.buffer->entities + i);
                        var gen = Ents.GetGeneration(jobData.buffer->state, entId);
                        var ent = new Ent(entId, gen, jobData.buffer->worldId);
                        jobData.jobData.Execute(in jobInfo, in ent, ref jobData.c0.Get(ent.id, ent.gen),ref jobData.c1.Get(ent.id, ent.gen),ref jobData.c2.Get(ent.id, ent.gen));
                    }
                    jobData.buffer->EndForEachRange();
                    
                }

            }
        }
    }
    #pragma warning restore
    
}